using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.CarModel;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public AppointmentService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }




        public async Task<Result<AppointmentDto>> CreateAppointment(Guid garageId, Guid? userId, AppointmentDtoForCreation appointmentDtoCreation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointmentPerDay = await _repoManager.AppointmentPerDay.GetAppointmentPerDayAsync(garageId, false);
            if (appointmentPerDay is null)
                throw new Exception("System did not have restrict appointment per day.");
            var checkEstimatedTimeValid = await _repoManager.Appointment.GetAppointmentAsync(appointmentDtoCreation.EstimatedAppointmentTime, false);
            if (checkEstimatedTimeValid.Count() >= appointmentPerDay!.CountPerDay)
                return Result<AppointmentDto>.Conflict(AppointmentErrors.GetAppointmentExceedLimitError(garageId, appointmentPerDay!.CountPerDay));

            if (userId.HasValue)
            {
                var user = await _repoManager.User.GetUserByIdAsync(userId.Value, false, "Roles");
                if (user is null)
                    return Result<AppointmentDto>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId.Value));

                if (!user.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Cashier)) || r.Name!.Equals(nameof(SystemRole.Customer))))
                    return Result<AppointmentDto>.Forbidden(UserErrors.GetUnAuthorizeUserError());
            }

            if (appointmentDtoCreation.CarModelId.HasValue)
            {
                var carModel = await _repoManager.CarModel.GetCarModelAsync(appointmentDtoCreation.CarModelId!.Value, false);
                if (carModel is null)
                    return Result<AppointmentDto>.NotFound(CarModelErrors.GetCarModelNotFoundError(appointmentDtoCreation.CarModelId!.Value));
            }

            if (appointmentDtoCreation.Services is null && appointmentDtoCreation.Packages is null)
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetInvalidAppointmentError());

            var appointment = _mapper.Map<Appointment>(appointmentDtoCreation);
            if (userId.HasValue) appointment.ApproveByEmployeeId = userId.Value;

            await _repoManager.Appointment.CreateAsync(garageId, appointment);

            if (appointmentDtoCreation.Packages is null || !appointmentDtoCreation.Packages.Any())
            {
                var createAppointmentDetailResult = await CreateAppointmentDetails(appointment.Id, appointmentDtoCreation.Services!);
                if (!createAppointmentDetailResult.IsSuccess)
                    return Result<AppointmentDto>.Failure(createAppointmentDetailResult);
                appointment.Price = createAppointmentDetailResult.Value;

            }
            else
            {
                var createAppointmentDetailResult = await CreateAppointmentDetailPackages(appointment.Id, appointmentDtoCreation.Packages, appointmentDtoCreation.Services);
                if (!createAppointmentDetailResult.IsSuccess)
                    return Result<AppointmentDto>.Failure(createAppointmentDetailResult);
                appointment.Price = createAppointmentDetailResult.Value;
            }


            await _repoManager.SaveAsync();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Result<AppointmentDto>.Ok(appointmentDto);
        }


        private async Task<Result<decimal>> CreateAppointmentDetails(
            Guid appointmentId,
            IEnumerable<AppointmentDetailDtoForCreation>? serviceInAppointmentDtos,
            Guid packageHistoryId = default)
        {
            // Early return if no services
            if (serviceInAppointmentDtos == null || !serviceInAppointmentDtos.Any())
                return Result<decimal>.Ok(0);

            // Check for duplicated services if not from a package
            if (packageHistoryId == default)
            {
                var serviceGroups = serviceInAppointmentDtos.GroupBy(s => s.ServiceId);
                var duplicateService = serviceGroups.FirstOrDefault(g => g.Count() > 1);

                if (duplicateService != null)
                    return Result<decimal>.BadRequest(AppointmentErrors.GetAppointmentServiceDuplicateError(duplicateService.Key));
            }

            // Extract all needed IDs upfront
            var serviceList = serviceInAppointmentDtos.ToList();
            var serviceIdList = serviceList.Select(s => s.ServiceId).ToList();
            var servicesWithDuplicateProducts = serviceList
                        .Where(s => s.ReplacementParts != null && s.ReplacementParts.Any())
                        .Where(s => s.ReplacementParts!
                            .GroupBy(rp => rp.ProductId)
                            .Any(g => g.Count() > 1))
                        .ToList();
            if (servicesWithDuplicateProducts.Any())
            {
                var duplicateProductIds = servicesWithDuplicateProducts.First().ReplacementParts!
                    .GroupBy(rp => rp.ProductId)
                    .First(g => g.Count() > 1);
                return Result<decimal>.BadRequest(AppointmentErrors.GetAppointmentHasDuplicateProductInServiceError(servicesWithDuplicateProducts.First().ServiceId, duplicateProductIds.Key.Value));
            }

            var productDtos = serviceList.Where(s => s.ReplacementParts != null && s.ReplacementParts.Any())
                                .SelectMany(s => s.ReplacementParts!)
                                .ToList();
            var productIdList = productDtos.Where(p => p.ProductId.HasValue).Select(p => p.ProductId!.Value).Distinct().ToList();

            // Get all required data from the database
            var services = await _repoManager.Service.GetServiceByIdsAsync(serviceIdList, false);
            if (services.Count() != serviceIdList.Count)
            {
                var missingIds = serviceIdList.Except(services.Select(s => s.Id));
                return Result<decimal>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(missingIds));
            }

            var serviceHistoryList = await _repoManager.ServiceHistory.GetServiceHistoriesAsync(serviceIdList, false);
            if (serviceHistoryList.Count() != serviceIdList.Count)
            {
                var notFoundServiceIds = serviceIdList.Except(serviceHistoryList.Select(s => s.ServiceId));
                return Result<decimal>.NotFound(ServiceHistoryErrors.GetServiceHistoryFoundNotMatchWithIdsError(notFoundServiceIds));
            }

            // Only query products if there are any
            IEnumerable<Product> productList = new List<Product>();
            IEnumerable<ProductHistory> productHistoryList = new List<ProductHistory>();

            if (productIdList != null && productIdList.Count != 0)
            {
                productList = await _repoManager.Product.GetProductsAsync(productIdList, false);
                if (productList.Count() != productIdList.Count)
                {
                    var missingIds = productIdList.Except(productList.Select(p => p.Id));
                    return Result<decimal>.NotFound(ProductErrors.GetProductsFoundNotMatchWithIdsError(missingIds));
                }

                productHistoryList = await _repoManager.ProductHistory.GetProductHistoriesAsync(productIdList, false);
                if (productHistoryList.Count() != productIdList.Count)
                {
                    var notFoundProductIds = productIdList.Except(productHistoryList.Select(p => p.ProductId));
                    return Result<decimal>.NotFound(ProductHistoryErrors.GetProductHistoryNotMatchWithProductId(notFoundProductIds));
                }
            }

            // Create dictionaries for efficient lookups
            var serviceHistoryDict = serviceHistoryList.ToDictionary(s => s.ServiceId);
            var productHistoryDict = productIdList.Any() ?
                productHistoryList.ToDictionary(p => p.ProductId) : null;

            decimal totalPrice = 0;
            var appointmentDetails = new List<AppointmentDetail>();
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            // Create appointment details
            foreach (var item in serviceList)
            {
                var serviceHistory = serviceHistoryDict[item.ServiceId];

                var newAppointmentDetail = new AppointmentDetail
                {
                    AppointmentId = appointmentId,
                    ServiceHistoryId = serviceHistory.Id,
                    CreateAt = now,
                    UpdatedAt = now,
                    Status = AppointmentDetailStatus.Pending,
                    PackageHistoryId = packageHistoryId != default ? packageHistoryId : null
                };

                // Add replacement parts if any
                if (item.ReplacementParts?.Any() == true && productHistoryDict != null)
                {
                    var replacementParts = new List<AppointmentReplacementPart>();

                    foreach (var part in item.ReplacementParts)
                    {
                        var productHistory = productHistoryDict[part.ProductId!.Value];

                        var replacementPart = new AppointmentReplacementPart
                        {
                            AppointmentDetailId = newAppointmentDetail.Id,
                            ProductHistoryId = productHistory.Id,
                            Quantity = part.Quantity,
                            Status = AppointmentReplacementPartStatus.Pending,
                            CreatedAt = now,
                            UpdatedAt = now
                        };

                        replacementParts.Add(replacementPart);
                        totalPrice += (productHistory.ProductPrice * part.Quantity);
                    }

                    newAppointmentDetail.AppointmentReplacementParts = replacementParts;
                }

                // Only add service price if not from a package
                if (newAppointmentDetail.PackageHistoryId == null)
                    totalPrice += serviceHistory.Price;

                appointmentDetails.Add(newAppointmentDetail);
            }

            // Bulk insert appointment details
            await _repoManager.AppointmentDetail.CreatesAsync([.. appointmentDetails]);

            return Result<decimal>.Ok(totalPrice);
        }

        private async Task<Result<decimal>> CreateAppointmentDetailPackages(Guid appointmentId, IEnumerable<AppointmentDetailPackageDtoForCreation>? packages, IEnumerable<AppointmentDetailDtoForCreation>? serviceInAppointmentDtos, bool isPackageImmediate = true)
        {
            if (packages is null || !packages.Any())
                return Result<decimal>.Ok(0);


            var checkDuplicatePackageId = packages
                .GroupBy(p => p.PackageId)
                .Where(s => s.Count() > 1)
                .Select(s => s.Key)
                .FirstOrDefault();

            if (checkDuplicatePackageId != default)
                return Result<decimal>.BadRequest(AppointmentErrors.GetAppointmentPackageDuplicateError(checkDuplicatePackageId));

            var packageIds = packages.Select(p => p.PackageId).ToList();

            decimal totalPrice = 0;
            var packageList = await _repoManager.Package.GetPackagesAsync(packageIds, false);
            if (packageList.Count() != packageIds.Count())
            {
                var notFoundPackageIds = packageIds.Except(packageList.Select(p => p.Id));
                return Result<decimal>.NotFound(PackageErrors.GetPackageFoundNotMatchWithIdError(notFoundPackageIds));
            }
            if (packageList.Any(p => !p.Type.Equals(PackageType.Immediate)) && !isPackageImmediate)
            {
                return Result<decimal>.BadRequest(AppointmentErrors.GetAppointmentWrongPackageTypeError());
            }

            var packageHistoryList = await _repoManager.PackageHistory.GetPackageHistoriesAsync(packageIds, false);
            if (packageHistoryList.Count() != packageIds.Count())
            {
                var notFoundPackageIds = packageIds.Except(packageHistoryList.Select(p => p.PackageId));
                return Result<decimal>.NotFound(PackageErrors.GetPackageHistoryFoundNotMatchWithIdsError(notFoundPackageIds));
            }

            var pacakgeDetail = new List<AppointmentDetailPackage>();
            var packageHistoryDict = packageHistoryList.ToDictionary(p => p.PackageId);
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            foreach (var package in packages)
            {
                var packageHistory = packageHistoryDict[package.PackageId];
                var newAppointmentDetail = new AppointmentDetailPackage()
                {
                    AppointmentId = appointmentId,
                    PackageHistoryId = packageHistory.Id,
                    CreatedAt = now,
                    UpdatedAt = now,
                    Status = AppointmentDetailPackageStatus.Pending
                };
                pacakgeDetail.Add(newAppointmentDetail);
                totalPrice += packageHistory.PackagePrice;
                var serviceOfPackageHistory = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(packageHistory.Id, false);
                var newServiceInAppointmentDtos = serviceOfPackageHistory.Select(x => new AppointmentDetailDtoForCreation()
                {
                    ServiceId = x.Id,
                });

                var result = await CreateAppointmentDetails(appointmentId, newServiceInAppointmentDtos, packageHistory.Id);
                if (!result.IsSuccess)
                    return Result<decimal>.Failure(result);
            }

            if (serviceInAppointmentDtos is not null && serviceInAppointmentDtos.Any())
            {
                var result2 = await CreateAppointmentDetails(appointmentId, serviceInAppointmentDtos);
                if (!result2.IsSuccess)
                    return Result<decimal>.Failure(result2);
                totalPrice += result2.Value;
            }

            await _repoManager.AppointmentDetailPackage.CreatesAsync([.. pacakgeDetail]);

            return Result<decimal>.Ok(totalPrice);
        }

        private async Task<Result<Appointment>> GetAppointment(Guid appointmentId, bool trackChanges)
        {
            var appointment = await _repoManager.Appointment.GetAppointmentAsync(appointmentId, trackChanges);
            if (appointment is null)
                return Result<Appointment>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            return Result<Appointment>.Ok(appointment);
        }

        public async Task<Result<ExpandoObject>> GetAppointment(Guid garageId, Guid appointmentId, string? fields = null)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<ExpandoObject>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointmentResult = await GetAppointment(appointmentId, false);
            if (!appointmentResult.IsSuccess)
                return Result<ExpandoObject>.Failure(appointmentResult);


            var appointment = appointmentResult.Value;

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            var appointmentDtoShaped = _dataShaper.Appointment.ShapeData(appointmentDto, fields);

            return Result<ExpandoObject>.Ok(appointmentDtoShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetAppointments(Guid garageId, AppointmentParameters appointmentParameters)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<IEnumerable<ExpandoObject>>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointments = await _repoManager.Appointment.GetAppointmentsAsync(garageId, appointmentParameters, false);

            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            var appointmentDtosShaped = _dataShaper.Appointment.ShapeData(appointmentDtos, appointmentParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(appointmentDtosShaped);
        }


    }
}
