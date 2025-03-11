using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.CarModel;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;

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


        public async Task<Result> ConfirmAppointment(Guid garageId, Guid appointmentId, Guid? userId, string? role, AppointmentConfirmationDto appointmentConfirmation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var user = await _repoManager.User.GetUserByIdAsync(userId!.Value, false);
            if (user is null)
                return Result.NotFound(UserErrors.GetUserNotFoundWithIdError(userId!.Value));

            var statusResult = role switch
            {
                nameof(SystemRole.Cashier) when !string.IsNullOrWhiteSpace(appointmentConfirmation.CanceledReason) => Result<AppointmentStatus>.Ok(AppointmentStatus.Rejected),
                nameof(SystemRole.Customer) when !string.IsNullOrWhiteSpace(appointmentConfirmation.CanceledReason) => Result<AppointmentStatus>.Ok(AppointmentStatus.Canceled),
                nameof(SystemRole.Cashier) when string.IsNullOrWhiteSpace(appointmentConfirmation.CanceledReason) => Result<AppointmentStatus>.Ok(AppointmentStatus.Approved),
                _ => Result.BadRequest(AppointmentErrors.GetNotAllowedToConfirmAppointmentError())
            };
            if (!statusResult.IsSuccess)
            {
                return statusResult;
            }

            var status = statusResult.GetValue<AppointmentStatus>();

            appointment.Status = status;
            appointment.CanceledReason = appointmentConfirmation.CanceledReason;
            appointment.EstimatedAppointmentTime = appointmentConfirmation.EstimatedAppointmentTime ?? appointment.EstimatedAppointmentTime;

            if (role!.Equals(nameof(SystemRole.Cashier)))
            {
                appointment.ApproveByEmployeeId = userId;
            }

            _repoManager.Appointment.Update(appointment);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result<AppointmentDto>> CreateAppointment(Guid garageId, Guid? userId, string? role, AppointmentDtoCreation appointmentDtoCreation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var user = userId.HasValue ? await _repoManager.User.GetUserByIdAsync(userId!.Value, false) : null;
            if (userId.HasValue && user is null)
                return Result<AppointmentDto>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId!.Value));

            var carModel = await _repoManager.CarModel.GetCarModelAsync(appointmentDtoCreation.CarModelId!.Value, false);
            if (carModel is null)
                return Result<AppointmentDto>.NotFound(CarModelErrors.GetCarModelNotFoundError(appointmentDtoCreation.CarModelId!.Value));

            if (appointmentDtoCreation.Services is null && appointmentDtoCreation.PackageIds is null)
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetInvalidAppointmentError());

            var appointment = _mapper.Map<Appointment>(appointmentDtoCreation);


            var test = await CreateAppointmentDetails(appointmentDtoCreation.Services!);
            return null;
        }

        public async Task<IEnumerable<AppointmentDetail>> CreateAppointmentDetails(IEnumerable<ServiceInAppointmentDto> serviceInAppointmentDtos)
        {
            var serviceList = serviceInAppointmentDtos.Where(s => s.ServiceId != null).Select(s => s.ServiceId!.Value).Distinct().ToList();

            var serviceInServiceList = await _repoManager.Service.GetServiceByIdsAsync(serviceList, false);

            if (serviceInServiceList.Count() != serviceList.Count)
            {
                var notFoundServiceIds = serviceList.Except(serviceInServiceList.Select(s => s.Id));
                throw new Exception($"Service with id {string.Join(", ", notFoundServiceIds)} not found");
            }

            var serviceHistoryList = await _repoManager.ServiceHistory.GetServiceHistoriesAsync(serviceList, false);

            return null;

        }
    }
}
