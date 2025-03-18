using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Appointment
{
    public class AppointmentErrors
    {
        public const string AppointmentNotFound = "Appointment not found";
        public const string InvalidAppointment = "Please provide at least one service or package.";
        public const string NotAllowedToConfirmAppointment = "You are not allowed to confirm this appointment";
        public const string AppointmentExceedLimit = "Garage {0} can only have {1} appoinment per day.";
        public const string AppointmentServiceDuplicate = "Service {0} already added to appointment";
        public const string AppointmentServiceDuplicateWithServiceInPackage = "Service {0} being duplicate with the service in package {1} appointment";
        public const string AppointmentPackageDuplicate = "Package {0} already added to appointment";
        public const string AppointmentHasDuplicateProductInService = "Service {0} has duplicate product {1}";
        public const string AppointmentWrongPackageType = "Package type is not correct";
        public const string AppointmentStatusNotPending = "Appointment {0} is not in pending status so cannot be confirm.";
        public const string AppointmentEstimatedAppointmentTimeInvalid = " Estimated appointment time must be greater than current time";
        public const string AppointmentEstimatedEndTimeInvalid = " Estimated end time must be greater than current time";
        public const string AppointmentStatusCompleted = "Appointment {0} is already completed";
        public const string AppointmentDetailIdRequired = "Appointment detail id is required";
        public const string AppointmentDetailNotFound = "Appointment detail {0} not found";
        public const string AppointmentDetailAlreadyCancelled = "Appointment detail {0} is already cancelled";
        public const string AppointmentDetailAlreadyRejected = "Appointment detail {0} is already rejected";
        public const string AppointmentReplacementPartNotFound = "Appointment replacement part not found";
        public const string CarConditionImageNotFound = "Car condition image not found with id {0}";

        public const string CustomerEmailRequired = "Customer email is required";
        public const string CustomerEmailInvalid = "Customer email is invalid";
        public const string CustomerPhoneRequired = "Customer phone is required";
        public const string CustomerPhoneInvalid = "Customer phone is invalid";
        public const string CustomerNameRequired = "Customer name is required";
        public const string EstimatedAppointmentTimeRequired = "Estimated appointment time is required";
        public const string CarModelIdRequired = "Car model id is required";

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

        public static ErrorsResult GetAppointmentServiceDuplicateError(Guid serviceId)
            => new ErrorsResult
            {
                Code = nameof(AppointmentServiceDuplicate),
                Description = string.Format(AppointmentServiceDuplicate, serviceId)
            };

        public static ErrorsResult GetAppointmentPackageDuplicateError(Guid packageId)
            => new ErrorsResult
            {
                Code = nameof(AppointmentPackageDuplicate),
                Description = string.Format(AppointmentPackageDuplicate, packageId)
            };

        public static ErrorsResult GetAppointmentHasDuplicateProductInServiceError(Guid serviceId, Guid productId)
            => new ErrorsResult
            {
                Code = nameof(AppointmentHasDuplicateProductInService),
                Description = string.Format(AppointmentHasDuplicateProductInService, serviceId, productId)
            };

        public static ErrorsResult GetAppointmentWrongPackageTypeError()
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentWrongPackageType),
                Description = AppointmentWrongPackageType
            };
        }

        public static ErrorsResult GetAppointmentNotFoundError(string verifyCode, string customnerEmail, string customerPhone, DateTimeOffset estimatedTime)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentNotFound),
                Description = $"Appointment has code {verifyCode} with customer email {customnerEmail}, customer phone {customerPhone}, estimated time {estimatedTime} not found"
            };
        }

        public static ErrorsResult GetAppointmentStatusNotPendingError(Guid appointmentId)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentStatusNotPending),
                Description = string.Format(AppointmentStatusNotPending, appointmentId)
            };
        }

        public static ErrorsResult GetAppointmentEstimatedTimeInvalidError()
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentEstimatedAppointmentTimeInvalid),
                Description = AppointmentEstimatedAppointmentTimeInvalid
            };
        }

        public static ErrorsResult GetAppointmentEstimatedEndTimeInvalidError()
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentEstimatedEndTimeInvalid),
                Description = AppointmentEstimatedEndTimeInvalid
            };
        }


        public static ErrorsResult GetAppointmentStatusCompletedError(Guid id)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentStatusCompleted),
                Description = string.Format(AppointmentStatusCompleted, id)
            };
        }

        public static ErrorsResult GetAppointmentCanNotUpdate(AppointmentStatus appointmentStatus)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentStatusCompleted),
                Description = $"Appointment is {appointmentStatus}, can not update."
            };
        }

        public static ErrorsResult GetAppointmentDetailIdRequired()
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentDetailIdRequired),
                Description = AppointmentDetailIdRequired
            };
        }

        public static ErrorsResult GetAppointmentDetailNotFound(IEnumerable<Guid> id)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentDetailNotFound),
                Description = string.Format(AppointmentDetailNotFound, string.Join(",", id))
            };
        }

        public static ErrorsResult GetAppointmentDetailNotFound(Guid id)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentDetailNotFound),
                Description = string.Format(AppointmentDetailNotFound, id)
            };
        }

        public static ErrorsResult GetAppointmentDetailAlreadyCancelled(IEnumerable<Guid> ids)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentDetailAlreadyCancelled),
                Description = string.Format(AppointmentDetailAlreadyCancelled, string.Join(", ", ids))
            };
        }

        public static ErrorsResult GetAppointmentDetailAlreadyRejectedError(IEnumerable<Guid> ids)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentDetailAlreadyRejected),
                Description = string.Format(AppointmentDetailAlreadyRejected, string.Join(", ", ids))
            };
        }

        public static ErrorsResult GetAppointmentReplacementPartNotFoundError()
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentReplacementPartNotFound),
                Description = AppointmentReplacementPartNotFound
            };
        }

        public static ErrorsResult GetAppointmentServiceDuplicateWithServiceInPackageError(IEnumerable<Guid> serviceIds, Guid packageId)
        {
            return new ErrorsResult
            {
                Code = nameof(AppointmentServiceDuplicateWithServiceInPackage),
                Description = string.Format(AppointmentServiceDuplicateWithServiceInPackage, string.Join(", ", serviceIds), packageId)
            };
        }

        public static ErrorsResult GetCarConditionImageNotFoundError(Guid id)
        {
            return new ErrorsResult
            {
                Code = nameof(CarConditionImageNotFound),
                Description = string.Format(CarConditionImageNotFound, id)
            };
        }
    }
}
