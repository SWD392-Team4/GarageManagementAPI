using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Appointment
{
    public class AppointmentErrors
    {
        public const string AppointmentNotFound = "Appointment not found";
        public const string InvalidAppointment = "Appointment cannot be created because the service list or package list cannot be exist at the same time with product for sell.";



        public static ErrorsResult GetAppointmentNotFoundError(Guid id)
            => new ErrorsResult
            {
                Code = nameof(AppointmentNotFound),
                Description = $"Appointment with id {id} not found"
            };

        public static ErrorsResult GetInvalidAppointmentError()
            => new ErrorsResult
            {
                Code = nameof(InvalidAppointment),
                Description = InvalidAppointment
            };
    }
}
