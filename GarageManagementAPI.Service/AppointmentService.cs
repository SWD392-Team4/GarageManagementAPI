using AutoMapper;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Customer;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
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

        public async Task<Result<AppointmentDto>> CreateAppointmentForCustomer(Guid garageId, CustomerCreateAppointmentDto appointmentDtoForCreation)
        {


        }

        public async Task<Result<AppointmentDto>> ValidateInputForCustomerToCreate(Guid garageId, CustomerCreateAppointmentDto appointmentDtoForCreation)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || (garage.WorkplaceType.Equals(WorkplaceType.Warehouse)))
                return Result<AppointmentDto>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var services = appointmentDtoForCreation.Services;
            var packages = appointmentDtoForCreation.Packages;

            if (services is null && packages is null)
                return Result<AppointmentDto>.BadRequest(AppointmentErrors.GetInvalidAppointmentError());

            if (services is not null && services.Any())
            {
                var servicesExist
            }
        }
    }
}
