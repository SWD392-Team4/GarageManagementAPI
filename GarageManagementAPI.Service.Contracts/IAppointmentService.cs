using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Cashier;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Customer;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentService
    {
        public Task<Result> ConfirmAppointment(Guid garageId, Guid appointmentId, Guid userId, CashierAppointmentDtoConfirmation confirmation);
        public Task<Result<AppointmentDto>> CreateAppointmentForCustomer(Guid id, CustomerCreateAppointmentDto appointmentDtoForCreation);
    }
}
