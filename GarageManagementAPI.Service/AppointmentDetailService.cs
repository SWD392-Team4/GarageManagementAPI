using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;

namespace GarageManagementAPI.Service
{
    public class AppointmentDetailService : IAppointmentDetailService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public AppointmentDetailService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result> CancelAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (appointment.Status == AppointmentStatus.Cancelled || appointment.Status == AppointmentStatus.Rejected || appointment.Status == AppointmentStatus.Completed)
                return Result.BadRequest(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            if (appointmentDetailDtoForCancellation.AppointmentDetailId is null || appointmentDetailDtoForCancellation.AppointmentDetailId.Length == 0)
                return Result.BadRequest(AppointmentErrors.GetAppointmentDetailIdRequired());

            var appointmentDetailAlreadyCancelled = appointment.AppointmentDetails.Where(ad => appointmentDetailDtoForCancellation.AppointmentDetailId!.Contains(ad.Id) && (ad.Status.Equals(AppointmentDetailStatus.Cancelled) || ad.Status.Equals(AppointmentDetailStatus.Declined)));
            if (appointmentDetailAlreadyCancelled.Any())
            {
                var alreadyCancelledAppointmentDetail = appointmentDetailAlreadyCancelled.Select(ad => ad.Id);
                return Result.Conflict(AppointmentErrors.GetAppointmentDetailAlreadyCancelled(alreadyCancelledAppointmentDetail));
            }

            var appointmentDetail = appointment.AppointmentDetails.Where(ad => appointmentDetailDtoForCancellation.AppointmentDetailId!.Contains(ad.Id));
            if (appointmentDetail.Count() != appointmentDetailDtoForCancellation.AppointmentDetailId!.Count())
            {
                var notFoundAppointmentDetail = appointmentDetailDtoForCancellation.AppointmentDetailId!.Except(appointmentDetail.Select(ad => ad.Id));
                return Result.NotFound(AppointmentErrors.GetAppointmentDetailNotFound(notFoundAppointmentDetail));
            }
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            foreach (var ad in appointmentDetail)
            {
                ad.Status = AppointmentDetailStatus.Cancelled;
                ad.UpdatedAt = now;
                ad.ServiceNote = appointmentDetailDtoForCancellation.CancelReason;
                appointment.Price -= ad.ServiceHistory.Price;
                appointment.EstimatedEndTime = appointment.EstimatedEndTime!.Value.Subtract(TimeSpan.FromHours(ad.ServiceHistory.Service.EstimatedHours));
                if (ad.AppointmentReplacementParts != null && ad.AppointmentReplacementParts.Any())
                {
                    foreach (var part in ad.AppointmentReplacementParts)
                    {
                        part.Status = AppointmentReplacementPartStatus.Cancelled;
                        part.UpdatedAt = now;
                        appointment.Price -= part.ProductHistory.ProductPrice;
                    }
                }
            }

            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result<IEnumerable<AppointmentDetailDto>>> CreateAppointmentDetails(Guid garageId, Guid appointmentId, IEnumerable<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreations)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<IEnumerable<AppointmentDetailDto>>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result<IEnumerable<AppointmentDetailDto>>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var serviceIdList = appointmentDetailDtoForCreations.Select(ad => ad.ServiceId).ToList();
            var serviceList = await _repoManager.Service.GetServiceByIdsAsync(serviceIdList, false);
            if (serviceList.Count() != serviceIdList.Count)
            {
                var notFoundServiceId = serviceIdList.Except(serviceList.Select(s => s.Id));
                return Result<IEnumerable<AppointmentDetailDto>>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(notFoundServiceId));
            }

            var serviceHistories = await _repoManager.ServiceHistory.GetServiceHistoriesAsync(serviceIdList, true);
            if (serviceHistories.Count() != serviceIdList.Count)
            {
                var notFoundServiceId = serviceIdList.Except(serviceHistories.Select(sh => sh.ServiceId));
                return Result<IEnumerable<AppointmentDetailDto>>.NotFound(ServiceHistoryErrors.GetServiceHistoryFoundNotMatchWithIdsError(notFoundServiceId));
            }

            var serviceHistoryIdList = serviceHistories.Select(sh => sh.Id).ToList();
            var appointmentDetails = appointment.AppointmentDetails.Select(s => s.ServiceHistoryId);
            if (serviceHistoryIdList.Intersect(appointmentDetails).Any())
            {
                var serviceHistoryId = serviceHistoryIdList.Intersect(appointmentDetails);
                return Result<IEnumerable<AppointmentDetailDto>>.BadRequest(AppointmentErrors.GetAppointmentServiceDuplicateError(serviceHistoryId.First()));
            }

            var servicesWithDuplicateProducts = appointmentDetailDtoForCreations
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
                return Result<IEnumerable<AppointmentDetailDto>>.BadRequest(AppointmentErrors.GetAppointmentHasDuplicateProductInServiceError(servicesWithDuplicateProducts.First().ServiceId, duplicateProductIds.Key.Value));
            }

            var productDtos = servicesWithDuplicateProducts.Where(s => s.ReplacementParts != null && s.ReplacementParts.Any())
                                .SelectMany(s => s.ReplacementParts!)
                                .ToList();
            var productIdList = productDtos.Where(p => p.ProductId.HasValue).Select(p => p.ProductId!.Value).Distinct().ToList();

            // Only query products if there are any
            IEnumerable<Product> productList = new List<Product>();
            IEnumerable<ProductHistory> productHistoryList = new List<ProductHistory>();

            if (productIdList != null && productIdList.Count != 0)
            {
                productList = await _repoManager.Product.GetProductsAsync(productIdList, false);
                if (productList.Count() != productIdList.Count)
                {
                    var missingIds = productIdList.Except(productList.Select(p => p.Id));
                    return Result<IEnumerable<AppointmentDetailDto>>.NotFound(ProductErrors.GetProductsFoundNotMatchWithIdsError(missingIds));
                }

                productHistoryList = await _repoManager.ProductHistory.GetProductHistoriesAsync(productIdList, false);
                if (productHistoryList.Count() != productIdList.Count)
                {
                    var notFoundProductIds = productIdList.Except(productHistoryList.Select(p => p.ProductId));
                    return Result<IEnumerable<AppointmentDetailDto>>.NotFound(ProductHistoryErrors.GetProductHistoryNotMatchWithProductId(notFoundProductIds));
                }
            }

            // Create dictionaries for efficient lookups
            var serviceHistoryDict = serviceHistories.ToDictionary(s => s.ServiceId);
            var productHistoryDict = productIdList.Any() ?
                productHistoryList.ToDictionary(p => p.ProductId) : null;

            decimal totalPrice = 0;
            int totalHours = 0;
            var newAppointmentDetails = new List<AppointmentDetail>();
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            // Create appointment details
            foreach (var item in appointmentDetailDtoForCreations)
            {
                var serviceHistory = serviceHistoryDict[item.ServiceId];

                var newAppointmentDetail = new AppointmentDetail
                {
                    AppointmentId = appointmentId,
                    ServiceHistoryId = serviceHistory.Id,
                    CreateAt = now,
                    UpdatedAt = now,
                    Status = AppointmentDetailStatus.Pending,
                    PackageHistoryId = null
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
                newAppointmentDetails.Add(newAppointmentDetail);
            }
            totalHours = serviceList.Sum(s => s.EstimatedHours);
            appointment.EstimatedEndTime = appointment.EstimatedAppointmentTime.AddHours(totalHours);
            appointment.Price += totalPrice;
            await _repoManager.AppointmentDetail.CreatesAsync([.. newAppointmentDetails]);
            await _repoManager.SaveAsync();

            var appointmentDetailDto = _mapper.Map<IEnumerable<AppointmentDetailDto>>(newAppointmentDetails);

            return Result<IEnumerable<AppointmentDetailDto>>.Ok(appointmentDetailDto);
        }

        public Task<Result<IEnumerable<AppointmentDetailDto>>> GetAppointmentDetailsAsync(Guid garageId, Guid appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> RejectAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (appointment.Status == AppointmentStatus.Cancelled || appointment.Status == AppointmentStatus.Rejected || appointment.Status == AppointmentStatus.Completed)
                return Result.BadRequest(AppointmentErrors.GetAppointmentCanNotUpdate(appointment.Status));

            if (appointmentDetailDtoForCancellation.AppointmentDetailId is null || appointmentDetailDtoForCancellation.AppointmentDetailId.Length == 0)
                return Result.BadRequest(AppointmentErrors.GetAppointmentDetailIdRequired());

            var appointmentDetailAlreadyCancelled = appointment.AppointmentDetails.Where(ad => appointmentDetailDtoForCancellation.AppointmentDetailId!.Contains(ad.Id) && (ad.Status.Equals(AppointmentDetailStatus.Cancelled) || ad.Status.Equals(AppointmentDetailStatus.Declined)));
            if (appointmentDetailAlreadyCancelled.Any())
            {
                var alreadyCancelledAppointmentDetail = appointmentDetailAlreadyCancelled.Select(ad => ad.Id);
                return Result.Conflict(AppointmentErrors.GetAppointmentDetailAlreadyRejectedError(alreadyCancelledAppointmentDetail));
            }

            var appointmentDetail = appointment.AppointmentDetails.Where(ad => appointmentDetailDtoForCancellation.AppointmentDetailId!.Contains(ad.Id));
            if (appointmentDetail.Count() != appointmentDetailDtoForCancellation.AppointmentDetailId!.Count())
            {
                var notFoundAppointmentDetail = appointmentDetailDtoForCancellation.AppointmentDetailId!.Except(appointmentDetail.Select(ad => ad.Id));
                return Result.NotFound(AppointmentErrors.GetAppointmentDetailNotFound(notFoundAppointmentDetail));
            }

            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            foreach (var ad in appointmentDetail)
            {
                ad.Status = AppointmentDetailStatus.Declined;
                ad.UpdatedAt = now;
                ad.ServiceNote = appointmentDetailDtoForCancellation.CancelReason;
                appointment.Price -= ad.ServiceHistory.Price;
                appointment.EstimatedEndTime = appointment.EstimatedEndTime!.Value.Subtract(TimeSpan.FromHours(ad.ServiceHistory.Service.EstimatedHours));
                if (ad.AppointmentReplacementParts != null && ad.AppointmentReplacementParts.Any())
                {
                    foreach (var part in ad.AppointmentReplacementParts)
                    {
                        part.Status = AppointmentReplacementPartStatus.Declined;
                        part.UpdatedAt = now;
                        appointment.Price -= part.ProductHistory.ProductPrice;
                    }
                }
            }

            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
