using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Service
{
    public class ServiceErrors
    {
        #region Service const errors
        public const string ServiceNotFound = "Service with id {0} doesn't exist.";
        public const string ServiceName = "Service with name already existed.";
        public const string NameRequired = "The service name is required.";
        public const string ServiceStatusRequired = "The service status is required";
        public const string ServiceStatusInvalid = "Invalid service status.";
        public const string ServiceNotFoundWithId = "Can not found service with id {0}.";
        #endregion

        #region static method
        public static ErrorsResult GetServiceNotFoundWithIdError()
        {
            return new()
            {
                Code = nameof(ServiceNotFoundWithId),
                Description = ServiceNotFoundWithId
            };
        }

        public static ErrorsResult GetServiceNotFoundError(Guid ServiceId) =>
            new()
            {
                Code = nameof(ServiceNotFoundWithId),
                Description = string.Format(ServiceNotFoundWithId, ServiceId)
            };

        public static ErrorsResult GetServiceNameAlreadyExistError(ServiceDtoForCreation serviceDtoForCreation) =>
             new()
             {
                 Code = nameof(ServiceName),
                 Description = string.Format(ServiceName, serviceDtoForCreation.ServiceName)
             };
        public static ErrorsResult GetServiceNameUpdateAlreadyExistError(ServiceDtoForUpdate serviceDtoForUpdate) =>
             new()
             {
                 Code = nameof(ServiceName),
                 Description = string.Format(ServiceName, serviceDtoForUpdate.ServiceName)
             };

        #endregion
    }
}
