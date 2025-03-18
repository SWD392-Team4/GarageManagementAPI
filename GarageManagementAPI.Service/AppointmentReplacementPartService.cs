using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Entities.Models;
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

            var productHistory = await _repoManager.ProductHistory.GetProductHistory(appointmentReplacementPartDtoForCreation.ProductId, false);

            if (productHistory is null)
                return Result<AppointmentReplacementPartDto>.NotFound(ProductHistoryErrors.GetProductHistoryNotFoundError(appointmentReplacementPartDtoForCreation.ProductId));

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

            var appointmentReplacementPart = await _repoManager.AppointmentReplacementPart.FindByCondition(arp => arp.Id.Equals(replacementPartId) && arp.AppointmentDetailId.Equals(appointmentDetailId), false).FirstOrDefaultAsync();

            if (appointmentReplacementPart is null)
                return Result<AppointmentReplacementPartDto>.NotFound(AppointmentErrors.GetAppointmentReplacementPartNotFoundError());

            var appointmentReplacementPartDto = _mapper.Map<AppointmentReplacementPartDto>(appointmentReplacementPart);

            return Result<AppointmentReplacementPartDto>.Ok(appointmentReplacementPartDto);
        }

        public async Task<Result<IEnumerable<AppointmentReplacementPartDto>>> GetAppointmentReplacementPartsAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId)
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

            var appointmentReplacementPart = await _repoManager.AppointmentReplacementPart.FindByCondition(arp => arp.AppointmentDetailId.Equals(appointmentDetailId), false).ToListAsync();

            var appointmentReplacementPartDto = _mapper.Map<IEnumerable<AppointmentReplacementPartDto>>(appointmentReplacementPart);

            return Result<IEnumerable<AppointmentReplacementPartDto>>.Ok(appointmentReplacementPartDto);
        }

        //public Task<Result> UpdateAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId, AppointmentReplacementPartDtoForUpdate appointmentReplacementPartDtoForUpdate)
        //{
        //    var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
        //    if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
        //        return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));
        //}


    }
}
