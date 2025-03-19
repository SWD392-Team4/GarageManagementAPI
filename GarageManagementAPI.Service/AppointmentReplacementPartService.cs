using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Service
{
    public class AppointmentReplacementPartService : IAppointmentReplacementPartService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public AppointmentReplacementPartService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<AppointmentReplacementPartDto>> CreateAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, AppointmentReplacementPartDtoForCreation appointmentReplacementPartDtoForCreation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentReplacementPartDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(appointmentId, true);
            if (appointment is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (!appointment.AppointmentDetails.Any(ad => ad.Id.Equals(appointmentDetailId)))
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound([appointmentDetailId]));

            var appointmentDetail = appointment.AppointmentDetails.FirstOrDefault(ad => ad.Id.Equals(appointmentDetailId));

            if (appointmentDetail.AppointmentReplacementParts != null && appointmentDetail.AppointmentReplacementParts.Any(arp => arp.ProductHistory.ProductId.Equals(appointmentReplacementPartDtoForCreation.ProductId)))
                return Result<AppointmentReplacementPartDto>.Conflict(AppointmentErrors.GetAppointmentHasDuplicateProductInServiceError(appointmentDetail.ServiceHistory.ServiceId, appointmentReplacementPartDtoForCreation.ProductId.Value));

            var productHistory = await _repoManager.ProductHistory.GetProductHistory(appointmentReplacementPartDtoForCreation.ProductId.Value, false);

            if (productHistory is null)
                return Result<AppointmentReplacementPartDto>.NotFound(ProductHistoryErrors.GetProductHistoryNotFoundError(appointmentReplacementPartDtoForCreation.ProductId.Value));


            var productQuantities = await _repoManager.ProductAtGarage.GetTotalStockForProduct(appointmentReplacementPartDtoForCreation.ProductId.Value, garageId);

            if (productQuantities < appointmentReplacementPartDtoForCreation.Quantity)
                return Result<AppointmentReplacementPartDto>.BadRequest(ProductAtGarageErrors.GetProductAtGarageNotEnoughQuantity(productHistory.ProductId));

            var appointmentReplacementPart = new AppointmentReplacementPart()
            {
                AppointmentDetailId = appointmentDetailId,
                ProductHistoryId = productHistory.Id,
                Quantity = appointmentReplacementPartDtoForCreation.Quantity
            };

            await _repoManager.AppointmentReplacementPart.CreateAsync(appointmentReplacementPart);
            appointment.Price += productHistory.ProductPrice * appointmentReplacementPart.Quantity;

            await _repoManager.SaveAsync();

            var appointmentReplacementPartDto = _mapper.Map<AppointmentReplacementPartDto>(appointmentReplacementPart);

            return Result<AppointmentReplacementPartDto>.Ok(appointmentReplacementPartDto);

        }

        public async Task<Result<AppointmentReplacementPartDto>> GetAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentReplacementPartDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.FindByCondition(a => a.Id.Equals(appointmentId), false).FirstOrDefaultAsync();
            if (appointment is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetail = await _repoManager.AppointmentDetail.FindByCondition(ad => ad.Id.Equals(appointmentDetailId), false).FirstOrDefaultAsync();
            if (appointmentDetail is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound([appointmentDetailId]));

            var appointmentReplacementPart = await _repoManager.AppointmentReplacementPart.GetAppointmentReplacementPartAsync(appointmentDetailId, replacementPartId, false);

            if (appointmentReplacementPart is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentReplacementPartNotFoundError());

            var appointmentReplacementPartDto = _mapper.Map<AppointmentReplacementPartDto>(appointmentReplacementPart);

            return Result<AppointmentReplacementPartDto>.Ok(appointmentReplacementPartDto);
        }

        public async Task<Result<IEnumerable<AppointmentReplacementPartDto>>> GetAppointmentReplacementPartsAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, AppoitnmentReplacementPartParameters appoitnmentReplacementPartParameters)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<IEnumerable<AppointmentReplacementPartDto>>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.FindByCondition(a => a.Id.Equals(appointmentId), false).FirstOrDefaultAsync();
            if (appointment is null)
                return Result<IEnumerable<AppointmentReplacementPartDto>>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetail = await _repoManager.AppointmentDetail.FindByCondition(ad => ad.Id.Equals(appointmentDetailId), false).FirstOrDefaultAsync();
            if (appointmentDetail is null)
                return Result<IEnumerable<AppointmentReplacementPartDto>>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound([appointmentDetailId]));

            var appointmentReplacementPart = await _repoManager.AppointmentReplacementPart.GetAppointmentReplacementPartsAsync(appointmentDetailId, appoitnmentReplacementPartParameters, false);

            var appointmentReplacementPartDto = _mapper.Map<IEnumerable<AppointmentReplacementPartDto>>(appointmentReplacementPart);

            return Result<IEnumerable<AppointmentReplacementPartDto>>.Ok(appointmentReplacementPartDto, appointmentReplacementPart.MetaData);
        }

        public async Task<Result> UpdateAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId, AppointmentReplacementPartDtoForUpdate appointmentReplacementPartDtoForUpdate)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(appointmentId, true);
            if (appointment is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (!appointment.AppointmentDetails.Any(ad => ad.Id.Equals(appointmentDetailId)))
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound([appointmentDetailId]));

            var appointmentDetail = appointment.AppointmentDetails.FirstOrDefault(ad => ad.Id.Equals(appointmentDetailId));
            if (appointmentDetail is null)
                return Result<IEnumerable<AppointmentReplacementPartDto>>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound([appointmentDetailId]));

            if (appointmentDetail.AppointmentReplacementParts != null && appointmentDetail.AppointmentReplacementParts.Any(arp => arp.ProductHistory.ProductId.Equals(appointmentReplacementPartDtoForUpdate.ProductId) && arp.Id != replacementPartId))
                return Result<AppointmentReplacementPartDto>.Conflict(AppointmentErrors.GetAppointmentHasDuplicateProductInServiceError(appointmentDetail.ServiceHistory.ServiceId, appointmentReplacementPartDtoForUpdate.ProductId.Value));

            var appointmentReplacementPart = await _repoManager.AppointmentReplacementPart.GetAppointmentReplacementPartAsync(appointmentDetailId, replacementPartId, true);
            if (appointmentReplacementPart is null)
                return Result<IEnumerable<AppointmentReplacementPartDto>>.NotFound(AppointmentErrors.GetAppointmentReplacementPartNotFoundError());

            var productHistory = await _repoManager.ProductHistory.GetProductHistory(appointmentReplacementPartDtoForUpdate.ProductId.Value, false);

            if (productHistory is null)
                return Result<AppointmentReplacementPartDto>.NotFound(ProductHistoryErrors.GetProductHistoryNotFoundError(appointmentReplacementPartDtoForUpdate.ProductId.Value));

            if (appointmentReplacementPart.Status == AppointmentReplacementPartStatus.Completed)
                return Result<IEnumerable<AppointmentReplacementPartDto>>.Conflict(AppointmentErrors.GetAppointmentStatusCompletedError(appointmentId));

            if (appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Approved && appointmentReplacementPart.Status == AppointmentReplacementPartStatus.Approved)
            {
                return Result<IEnumerable<AppointmentReplacementPartDto>>.Conflict(AppointmentErrors.GetAppointmentReplacementPartAlreadyApporoved(replacementPartId));
            }
            else if (appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Declined && appointmentReplacementPart.Status == AppointmentReplacementPartStatus.Declined)
            {
                return Result<IEnumerable<AppointmentReplacementPartDto>>.Conflict(AppointmentErrors.GetAppointmentReplacementPartAlreadyDeclined(replacementPartId));
            }
            else if (appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Cancelled && appointmentReplacementPart.Status == AppointmentReplacementPartStatus.Cancelled)
            {
                return Result<IEnumerable<AppointmentReplacementPartDto>>.Conflict(AppointmentErrors.GetAppointmentReplacementPartAlreadyCancelled(replacementPartId));
            }




            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            if (appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Approved && appointmentReplacementPart.Status != AppointmentReplacementPartStatus.Approved)
            {
                if (appointmentReplacementPart.Quantity != appointmentReplacementPartDtoForUpdate.Quantity)
                {
                    return Result<IEnumerable<AppointmentReplacementPartDto>>.Conflict(AppointmentErrors.GetAppointmentReplacementPartQuantityNotMatch());
                }

                var deductedList = await _repoManager.ProductAtGarage.DeductProductQuantityFromGarageAsync(productHistory.ProductId, garageId, appointmentReplacementPartDtoForUpdate.Quantity);
                var appointmentReplacementPart_ProductAtGarages = new List<AppointmentReplacementPart_ProductAtGarage>();
                foreach (var (productAtGarageId, deductedQuantity) in deductedList)
                {
                    if (deductedQuantity != 0)
                    {
                        var appointmentReplacementPart_ProductAtGarageExist = appointmentReplacementPart.AppointmentReplacementPart_ProductAtGarages.Where(pr => pr.ProductAtGarageId == productAtGarageId).FirstOrDefault();
                        if (appointmentReplacementPart_ProductAtGarageExist != default)
                        {
                            appointmentReplacementPart_ProductAtGarageExist.QuantityUsed += deductedQuantity;
                            continue;
                        }
                        else
                        {
                            var invoiceSellProduct_ProductAtGarage = new AppointmentReplacementPart_ProductAtGarage()
                            {
                                ProductAtGarageId = productAtGarageId,
                                AppointmentReplacementPartId = replacementPartId,
                                QuantityUsed = deductedQuantity
                            };
                            appointmentReplacementPart_ProductAtGarages.Add(invoiceSellProduct_ProductAtGarage);
                        }
                    }
                }
                if (appointmentReplacementPart_ProductAtGarages.Count > 0)
                {
                    await _repoManager.AppointmentReplacementPart_ProductAtGarage.CreatesAsync([.. appointmentReplacementPart_ProductAtGarages]);
                }
                appointment.Price += appointmentReplacementPart.ProductHistory.ProductPrice * appointmentReplacementPart.Quantity + productHistory.ProductPrice * appointmentReplacementPartDtoForUpdate.Quantity;
                appointmentReplacementPart.ProductHistoryId = productHistory.Id;
                appointmentReplacementPart.Quantity = appointmentReplacementPartDtoForUpdate.Quantity;
                appointmentReplacementPart.Status = appointmentReplacementPartDtoForUpdate.Status;
                appointmentReplacementPart.UpdatedAt = now;
            }
            else if ((appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Declined ||
                appointmentReplacementPartDtoForUpdate.Status == AppointmentReplacementPartStatus.Cancelled) && (appointmentReplacementPart.Status != AppointmentReplacementPartStatus.Declined || appointmentReplacementPartDtoForUpdate.Status != AppointmentReplacementPartStatus.Cancelled))
            {
                var appointmentReplacementPart_ProductAtGarage = await _repoManager.AppointmentReplacementPart_ProductAtGarage.FindByCondition(arp => arp.AppointmentReplacementPartId.Equals(replacementPartId), false).ToListAsync();
                var productAtGarageIds = appointmentReplacementPart_ProductAtGarage.Select(arp => arp.ProductAtGarageId).ToList();
                var productAtGarages = await _repoManager.ProductAtGarage.FindByCondition(pag => productAtGarageIds.Contains(pag.Id), true).ToListAsync();
                foreach (var item in productAtGarages)
                {
                    item.Quantity += appointmentReplacementPart_ProductAtGarage.FirstOrDefault(arp => arp.ProductAtGarageId.Equals(item.Id)).QuantityUsed;
                }
                foreach (var item in appointmentReplacementPart.AppointmentReplacementPart_ProductAtGarages)
                {
                    _repoManager.AppointmentReplacementPart_ProductAtGarage.Delete(item);
                }
                appointment.Price -= appointmentReplacementPart.ProductHistory.ProductPrice * appointmentReplacementPart.Quantity + productHistory.ProductPrice * appointmentReplacementPartDtoForUpdate.Quantity;
                appointmentReplacementPart.ProductHistoryId = productHistory.Id;
                appointmentReplacementPart.Quantity = 0;
                appointmentReplacementPart.Status = appointmentReplacementPartDtoForUpdate.Status;
                appointmentReplacementPart.UpdatedAt = now;
            }
            else
            {
                var productQuantities = await _repoManager.ProductAtGarage.GetTotalStockForProduct(appointmentReplacementPartDtoForUpdate.ProductId.Value, garageId);

                if (productQuantities < appointmentReplacementPartDtoForUpdate.Quantity)
                    return Result<AppointmentReplacementPartDto>.BadRequest(ProductAtGarageErrors.GetProductAtGarageNotEnoughQuantity(productHistory.ProductId));

                appointmentReplacementPart.Quantity = appointmentReplacementPartDtoForUpdate.Quantity;
                appointmentReplacementPart.Status = AppointmentReplacementPartStatus.Pending;
                appointmentReplacementPart.ProductHistoryId = productHistory.Id;
                appointmentReplacementPart.UpdatedAt = now;
            }

            await _repoManager.SaveAsync();

            return Result.Ok();
        }


    }
}
