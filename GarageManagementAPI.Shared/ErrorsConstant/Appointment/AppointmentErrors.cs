using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Appointment
{
    public class AppointmentErrors
    {
        public const string AppointmentNotFound = "Appointment not found";
        public const string InvalidAppointment = "Please provide at least one service or package.";
        public const string NotAllowedToConfirmAppointment = "You are not allowed to confirm this appointment";
        public const string AppointmentExceedLimit = "Garage {0} can only have {1} appoinment per day.";


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

        public static ErrorsResult GetNotAllowedToConfirmAppointmentError()
            => new ErrorsResult
            {
                Code = nameof(NotAllowedToConfirmAppointment),
                Description = NotAllowedToConfirmAppointment
            };

        public static ErrorsResult GetAppointmentExceedLimitError(Guid garageId, int numberPer)
            => new ErrorsResult
            {
                Code = nameof(AppointmentExceedLimit),
                Description = string.Format(AppointmentExceedLimit, garageId, numberPer),
            };

    }
}
