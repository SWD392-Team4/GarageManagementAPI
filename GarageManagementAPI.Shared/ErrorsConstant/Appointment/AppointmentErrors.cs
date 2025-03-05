using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Appointment
{
    public class AppointmentErrors
    {
        public const string AppointmentNotFound = "Appointment not found";

        public static ErrorsResult GetAppointmentNotFoundError(Guid id)
            => new ErrorsResult
            {
                Code = nameof(AppointmentNotFound),
                Description = $"Appointment with id {id} not found"
            };
    }
}
