using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;

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

        public async Task<Result> ApproveAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds)
        {
            return await UpdateAppointmentDetailsStatusAsync(garageId, appointmentId, appointmentDetailIds, AppointmentDetailStatus.Approved);
        }

        public async Task<Result> CancelAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds)
        {
            return await UpdateAppointmentDetailsStatusAsync(garageId, appointmentId, appointmentDetailIds, AppointmentDetailStatus.Declined);
        }

        private async Task<Result> UpdateAppointmentDetailsStatusAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds, AppointmentDetailStatus status)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            if (appointment.AppointmentDetails.Count != 0)
            {
                var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
                foreach (var ad in appointment.AppointmentDetails)
                {
                    if (appointmentDetailIds.Contains(ad.Id))
                    {
                        ad.Status = status;
                        ad.UpdatedAt = now;
                    }
                }
            }

            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result<IEnumerable<AppointmentDetailDto>>> CreateAppointmentDetails(Guid garageId, Guid appointmentId, IEnumerable<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreations)
        {
            throw new NotImplementedException();
        }


        public Task<Result<IEnumerable<AppointmentDetailDto>>> GetAppointmentDetailAsync(Guid garageId, Guid appointmentId)
        {
            throw new NotImplementedException();
        }

        Task<Result> IAppointmentDetailService.DeleteAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds)
        {
            throw new NotImplementedException();
        }
    }
}
