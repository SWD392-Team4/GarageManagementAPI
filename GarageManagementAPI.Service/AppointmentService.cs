using AutoMapper;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.RequestFeatures;
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

        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges)
        {
            var appointments = await _repoManager.Appointment.GetAppointmentsAsync(appointmentParameters, trackChanges);

            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return Result<IEnumerable<AppointmentDto>>.Ok(appointmentsDto, appointments.MetaData);
        }
    }
}
