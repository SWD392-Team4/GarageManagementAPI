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
using System.Collections.Generic;
using System.ComponentModel;
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

            if (!ValidEstimatedTime(appointmentDtoCreation.EstimatedAppointmentTime!.Value))
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetAppointmentEstimatedTimeInvalidError());

            var checkEstimatedTimeValid = await _repoManager.Appointment.GetAppointmentAsync(appointmentDtoCreation.EstimatedAppointmentTime!.Value, false);
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

            if ((appointmentDtoCreation.Services is null || !appointmentDtoCreation.Services.Any()) && (appointmentDtoCreation.Packages is null || !appointmentDtoCreation.Packages.Any()))
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetInvalidAppointmentError());

            var appointment = _mapper.Map<Appointment>(appointmentDtoCreation);
            if (userId.HasValue) appointment.ApproveByEmployeeId = userId.Value;

            await _repoManager.Appointment.CreateAsync(garageId, appointment);

            if (appointmentDtoCreation.Packages is null || !appointmentDtoCreation.Packages.Any())
            {
                var createAppointmentDetailResult = await CreateAppointmentDetails(appointment.Id, appointmentDtoCreation.Services!);
                if (!createAppointmentDetailResult.IsSuccess)
                    return Result<AppointmentDto>.Failure(createAppointmentDetailResult);
                appointment.Price = createAppointmentDetailResult.Value.totalPrice;
                appointment.EstimatedEndTime = appointment.EstimatedAppointmentTime.AddHours(createAppointmentDetailResult.Value.totalHours);
                appointment.AppointmentType = AppointmentType.ServicePackageBooking;

            }
            else
            {
                var createAppointmentDetailResult = await CreateAppointmentDetailPackages(appointment.Id, appointmentDtoCreation.Packages, appointmentDtoCreation.Services);
                if (!createAppointmentDetailResult.IsSuccess)
                    return Result<AppointmentDto>.Failure(createAppointmentDetailResult);
                appointment.Price = createAppointmentDetailResult.Value.totalPrice;
                appointment.EstimatedEndTime = appointment.EstimatedAppointmentTime.AddHours(createAppointmentDetailResult.Value.totalHours);
                appointment.AppointmentType = AppointmentType.ServiceBooking;
            }


            await _repoManager.SaveAsync();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Result<AppointmentDto>.Ok(appointmentDto);
        }


        private async Task<Result<(decimal totalPrice, int totalHours)>> CreateAppointmentDetails(
            Guid appointmentId,
            IEnumerable<AppointmentDetailDtoForCreation>? serviceInAppointmentDtos,
            Guid packageHistoryId = default)
        {
            // Early return if no services
            if (serviceInAppointmentDtos == null || !serviceInAppointmentDtos.Any())
                return Result<(decimal totalPrice, int totalHours)>.Ok((0, 0));

            // Check for duplicated services if not from a package
            if (packageHistoryId == default)
            {
                var serviceGroups = serviceInAppointmentDtos.GroupBy(s => s.ServiceId);
                var duplicateService = serviceGroups.FirstOrDefault(g => g.Count() > 1);

                if (duplicateService != null)
                    return Result<(decimal totalPrice, int totalHours)>.BadRequest(AppointmentErrors.GetAppointmentServiceDuplicateError(duplicateService.Key));
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
                return Result<(decimal totalPrice, int totalHours)>.BadRequest(AppointmentErrors.GetAppointmentHasDuplicateProductInServiceError(servicesWithDuplicateProducts.First().ServiceId, duplicateProductIds.Key.Value));
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
                return Result<(decimal totalPrice, int totalHours)>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(missingIds));
            }

            var serviceHistoryList = await _repoManager.ServiceHistory.GetServiceHistoriesAsync(serviceIdList, false);
            if (serviceHistoryList.Count() != serviceIdList.Count)
            {
                var notFoundServiceIds = serviceIdList.Except(serviceHistoryList.Select(s => s.ServiceId));
                return Result<(decimal totalPrice, int totalHours)>.NotFound(ServiceHistoryErrors.GetServiceHistoryFoundNotMatchWithIdsError(notFoundServiceIds));
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
                    return Result<(decimal totalPrice, int totalHours)>.NotFound(ProductErrors.GetProductsFoundNotMatchWithIdsError(missingIds));
                }

                productHistoryList = await _repoManager.ProductHistory.GetProductHistoriesAsync(productIdList, false);
                if (productHistoryList.Count() != productIdList.Count)
                {
                    var notFoundProductIds = productIdList.Except(productHistoryList.Select(p => p.ProductId));
                    return Result<(decimal totalPrice, int totalHours)>.NotFound(ProductHistoryErrors.GetProductHistoryNotMatchWithProductId(notFoundProductIds));
                }
            }

            // Create dictionaries for efficient lookups
            var serviceHistoryDict = serviceHistoryList.ToDictionary(s => s.ServiceId);
            var productHistoryDict = productIdList.Any() ?
                productHistoryList.ToDictionary(p => p.ProductId) : null;

            decimal totalPrice = 0;
            int totalHours = 0;
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
            totalHours = services.Sum(s => s.EstimatedHours);

            // Bulk insert appointment details
            await _repoManager.AppointmentDetail.CreatesAsync([.. appointmentDetails]);

            return Result<(decimal totalPrice, int totalHours)>.Ok((totalPrice, totalHours));
        }

        private async Task<Result<(decimal totalPrice, int totalHours)>> CreateAppointmentDetailPackages(Guid appointmentId, IEnumerable<AppointmentDetailPackageDtoForCreation>? packages, IEnumerable<AppointmentDetailDtoForCreation>? serviceInAppointmentDtos, bool isPackageImmediate = true)
        {
            if (packages is null || !packages.Any())
                return Result<(decimal totalPrice, int totalHours)>.Ok((0, 0));


            var checkDuplicatePackageId = packages
                .GroupBy(p => p.PackageId)
                .Where(s => s.Count() > 1)
                .Select(s => s.Key)
                .FirstOrDefault();

            if (checkDuplicatePackageId != default)
                return Result<(decimal totalPrice, int totalHours)>.BadRequest(AppointmentErrors.GetAppointmentPackageDuplicateError(checkDuplicatePackageId));

            var packageIds = packages.Select(p => p.PackageId).ToList();

            decimal totalPrice = 0;
            int totalHours = 0;
            var packageList = await _repoManager.Package.GetPackagesAsync(packageIds, false);
            if (packageList.Count() != packageIds.Count())
            {
                var notFoundPackageIds = packageIds.Except(packageList.Select(p => p.Id));
                return Result<(decimal totalPrice, int totalHours)>.NotFound(PackageErrors.GetPackageFoundNotMatchWithIdError(notFoundPackageIds));
            }
            if (packageList.Any(p => !p.Type.Equals(PackageType.Immediate)) && !isPackageImmediate)
            {
                return Result<(decimal totalPrice, int totalHours)>.BadRequest(AppointmentErrors.GetAppointmentWrongPackageTypeError());
            }

            var packageHistoryList = await _repoManager.PackageHistory.GetPackageHistoriesAsync(packageIds, false);
            if (packageHistoryList.Count() != packageIds.Count())
            {
                var notFoundPackageIds = packageIds.Except(packageHistoryList.Select(p => p.PackageId));
                return Result<(decimal totalPrice, int totalHours)>.NotFound(PackageErrors.GetPackageHistoryFoundNotMatchWithIdsError(notFoundPackageIds));
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
                    return Result<(decimal totalPrice, int totalHours)>.Failure(result);

                totalHours += result.Value.totalHours;
            }

            if (serviceInAppointmentDtos is not null && serviceInAppointmentDtos.Any())
            {
                var result2 = await CreateAppointmentDetails(appointmentId, serviceInAppointmentDtos);
                if (!result2.IsSuccess)
                    return Result<(decimal totalPrice, int totalHours)>.Failure(result2);
                totalPrice += result2.Value.totalPrice;
                totalHours += result2.Value.totalHours;
            }

            await _repoManager.AppointmentDetailPackage.CreatesAsync([.. pacakgeDetail]);

            return Result<(decimal totalPrice, int totalHours)>.Ok((totalPrice, totalHours));
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

        public async Task<Result<IEnumerable<ExpandoObject>>> GetAppointments(Guid garageId, AppointmentParameters appointmentParameters, Guid userId, string role)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<IEnumerable<ExpandoObject>>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var isEmployee = role.Equals(nameof(SystemRole.Cashier));
            var user = new User();

            if (isEmployee)
            {
                user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");
                if (user is null)
                    return Result<IEnumerable<ExpandoObject>>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));

                if (user.EmployeeInfo is null || user.EmployeeInfo.WorkplaceId != garageId)
                    return Result<IEnumerable<ExpandoObject>>.Unauthorized(UserErrors.GetUnAuthorizeUserError());
            }

            if (!isEmployee)
            {
                user = await _repoManager.User.GetUserByIdAsync(userId, false);
                appointmentParameters.CustomerPhoneNumber = user!.PhoneNumber;
                appointmentParameters.CustomerEmail = user!.Email;
            }

            var appointments = await _repoManager.Appointment.GetAppointmentsAsync(garageId, appointmentParameters, false);

            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            var appointmentDtosShaped = _dataShaper.Appointment.ShapeData(appointmentDtos, appointmentParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(appointmentDtosShaped, appointments.MetaData);
        }

        public async Task<Result<AppointmentDto>> GetAppointmentForGuest(Guid garageId, AppointmentDtoForGuest appointmentDtoForGuest)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentDtoForGuest.VerifyCode, appointmentDtoForGuest.CustomerEmail!, appointmentDtoForGuest.CustomerPhoneNumber!, appointmentDtoForGuest.EstimatedTime!.Value, false);
            if (appointment is null)
                return Result<AppointmentDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentDtoForGuest.VerifyCode!, appointmentDtoForGuest.CustomerEmail!, appointmentDtoForGuest.CustomerPhoneNumber!, appointmentDtoForGuest.EstimatedTime!.Value));

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return Result<AppointmentDto>.Ok(appointmentDto);
        }

        public async Task<Result> CancelAppointmentForGuest(Guid garageId, AppointmentDtoForGuestCancellation appointmentDtoForGuest)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentDtoForGuest.VerifyCode, appointmentDtoForGuest.CustomerEmail!, appointmentDtoForGuest.CustomerPhoneNumber!, appointmentDtoForGuest.EstimatedTime!.Value, false);
            if (appointment is null)
                return Result<AppointmentDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentDtoForGuest.VerifyCode!, appointmentDtoForGuest.CustomerEmail!, appointmentDtoForGuest.CustomerPhoneNumber!, appointmentDtoForGuest.EstimatedTime!.Value));

            if (!CanUpdateAppointment(appointment.Status))
                return Result<AppointmentDto>.Conflict(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            appointment.Status = AppointmentStatus.Cancelled;
            appointment.CancelledAt = DateTime.UtcNow.SEAsiaStandardTime();
            appointment.CanceledReason = appointmentDtoForGuest.CancelledReason ?? "None";

            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            if (appointment.AppointmentDetails.Count != 0)
            {
                foreach (var item in appointment.AppointmentDetails)
                {
                    item.Status = AppointmentDetailStatus.Cancelled;
                    item.UpdatedAt = now;
                    if (item.AppointmentReplacementParts.Any())
                    {
                        foreach (var part in item.AppointmentReplacementParts)
                        {
                            part.Status = AppointmentReplacementPartStatus.Cancelled;
                            part.UpdatedAt = now;
                        }
                    }
                }

                _repoManager.AppointmentDetail.Updates([.. appointment.AppointmentDetails]);
            }

            if (appointment.AppointmentDetailPackages.Count != 0)
            {
                foreach (var item in appointment.AppointmentDetailPackages)
                {
                    item.Status = AppointmentDetailPackageStatus.Cancelled;
                    item.UpdatedAt = now;
                }
                _repoManager.AppointmentDetailPackage.Updates([.. appointment.AppointmentDetailPackages]);
            }


            _repoManager.Appointment.Update(appointment);
            await _repoManager.SaveAsync();

            return Result.Ok();

        }

        public async Task<Result> CancelAppointment(Guid garageId, Guid appointmentId, Guid userId, string role, AppointmentDtoForCancellation appointmentDtoForCancellation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result<AppointmentDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");
            if (user is null)
                return Result<AppointmentDto>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));

            if (user.EmployeeInfo is null || user.EmployeeInfo.WorkplaceId != garageId)
                return Result<AppointmentDto>.Unauthorized(UserErrors.GetUnAuthorizeUserError());

            if (!CanUpdateAppointment(appointment.Status))
                return Result<AppointmentDto>.Conflict(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            var isEmployee = role.Equals(nameof(SystemRole.Cashier));


            appointment.RejectByEmployeeId = isEmployee ? userId : null;
            appointment.Status = isEmployee ? AppointmentStatus.Rejected : AppointmentStatus.Cancelled;
            appointment.CancelledAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            appointment.CanceledReason = appointmentDtoForCancellation.CancelledReason ?? "None";

            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            if (appointment.AppointmentDetails.Any())
            {
                foreach (var item in appointment.AppointmentDetails)
                {
                    item.Status = isEmployee ? AppointmentDetailStatus.Declined : AppointmentDetailStatus.Cancelled;
                    item.UpdatedAt = now;
                    if (item.AppointmentReplacementParts.Any())
                    {
                        foreach (var part in item.AppointmentReplacementParts)
                        {
                            part.Status = isEmployee ? AppointmentReplacementPartStatus.Declined : AppointmentReplacementPartStatus.Cancelled;
                            part.UpdatedAt = now;
                        }
                    }
                }

                _repoManager.AppointmentDetail.Updates([.. appointment.AppointmentDetails]);
            }

            if (appointment.AppointmentDetailPackages.Any())
            {
                foreach (var item in appointment.AppointmentDetailPackages)
                {
                    item.Status = isEmployee ? AppointmentDetailPackageStatus.Declined : AppointmentDetailPackageStatus.Cancelled;
                    item.UpdatedAt = now;
                }
                _repoManager.AppointmentDetailPackage.Updates([.. appointment.AppointmentDetailPackages]);
            }


            _repoManager.Appointment.Update(appointment);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> ConfirmAppointment(Guid garageId, Guid appointmentId, Guid userId, AppointmentDtoForConfirmation appointmentConfirmation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result<AppointmentDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (!CanUpdateAppointment(appointment.Status))
                return Result<AppointmentDto>.Conflict(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            if (appointmentConfirmation.EstimatedAppointmentTime != null && !ValidEstimatedTime(appointment.EstimatedAppointmentTime))
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetAppointmentEstimatedTimeInvalidError());


            if (appointmentConfirmation.EstimatedAppointmentTime != null)
            {
                appointment.EstimatedAppointmentTime = appointmentConfirmation.EstimatedAppointmentTime.Value;
            }

            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");
            if (user is null)
                return Result<AppointmentDto>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));

            if (user.EmployeeInfo is null || user.EmployeeInfo.WorkplaceId != garageId)
                return Result<AppointmentDto>.Unauthorized(UserErrors.GetUnAuthorizeUserError());


            appointment.ApproveByEmployeeId = userId;
            appointment.Status = AppointmentStatus.Approved;
            appointment.ApprovedAt = DateTime.UtcNow.SEAsiaStandardTime();
            _repoManager.Appointment.Update(appointment);
            await _repoManager.SaveAsync();

            return Result.Ok();

        }

        private bool ValidEstimatedTime(DateTimeOffset estimatedTime)
        {
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            return estimatedTime > now;
        }

        public async Task<Result> UpdateAppointmentInformation(Guid garageId, Guid appointmentId, Guid userId, AppointmentDtoForUpdate appointmentDtoForUpdate)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result<AppointmentDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (!CanUpdateAppointment(appointment.Status))
                return Result<AppointmentDto>.Conflict(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");
            if (user is null)
                return Result<AppointmentDto>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));

            if (user.EmployeeInfo is null || user.EmployeeInfo.WorkplaceId != garageId)
                return Result<AppointmentDto>.Unauthorized(UserErrors.GetUnAuthorizeUserError());

            if (appointmentDtoForUpdate.EstimatedEndTime != null)
            {
                if (appointmentDtoForUpdate.EstimatedEndTime != appointment.EstimatedEndTime)
                {
                    if (!ValidEstimatedTime(appointmentDtoForUpdate.EstimatedEndTime.Value) ||
                        appointmentDtoForUpdate.EstimatedEndTime < appointmentDtoForUpdate.EstimatedAppointmentTime)
                    {
                        return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetAppointmentEstimatedEndTimeInvalidError());
                    }
                }
            }

            if (appointmentDtoForUpdate.EstimatedAppointmentTime != null)
            {
                if (appointmentDtoForUpdate.EstimatedAppointmentTime != appointment.EstimatedAppointmentTime)
                {
                    if (!ValidEstimatedTime(appointmentDtoForUpdate.EstimatedAppointmentTime.Value))
                    {
                        return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetAppointmentEstimatedTimeInvalidError());
                    }
                }
            }

            if (IsAppointmentUpdated(appointmentDtoForUpdate, appointment))
            {
                if (appointmentDtoForUpdate.CarModelId.HasValue)
                {
                    var carModel = await _repoManager.CarModel.GetCarModelAsync(appointmentDtoForUpdate.CarModelId!.Value, false);
                    if (carModel is null)
                        return Result<AppointmentDto>.NotFound(CarModelErrors.GetCarModelNotFoundError(appointmentDtoForUpdate.CarModelId!.Value));
                }
                appointment = _mapper.Map(appointmentDtoForUpdate, appointment);
                _repoManager.Appointment.Update(appointment);
                await _repoManager.SaveAsync();
            }

            return Result.Ok();
        }

        private bool IsAppointmentUpdated(AppointmentDtoForUpdate dto, Appointment entity)
        {
            if (dto.CarModelId.HasValue && dto.CarModelId != entity.CarModelId)
                return true;

            if (dto.Mileage.HasValue && dto.Mileage != entity.Mileage)
                return true;

            if (dto.CustomerName != null && dto.CustomerName != entity.CustomerName)
                return true;

            if (dto.CustomerPhoneNumber != null && dto.CustomerPhoneNumber != entity.CustomerPhoneNumber)
                return true;

            if (dto.CustomerEmail != null && dto.CustomerEmail != entity.CustomerEmail)
                return true;

            if (dto.EstimatedAppointmentTime.HasValue && dto.EstimatedAppointmentTime != entity.EstimatedAppointmentTime)
                return true;

            if (dto.EstimatedEndTime.HasValue && dto.EstimatedEndTime != entity.EstimatedEndTime)
                return true;

            if (dto.CarLicensePlateNumber != null && dto.CarLicensePlateNumber != entity.CarLicensePlateNumber)
                return true;

            return false;
        }

        public bool CanUpdateAppointment(AppointmentStatus currentStatus)
        {
            return currentStatus != AppointmentStatus.Rejected &&
                   currentStatus != AppointmentStatus.Cancelled &&
                   currentStatus != AppointmentStatus.Completed;
        }
    }

}
