using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Service
{
    public class ServiceErrors
    {
        #region Service const errors
        public const string ServiceNotFound = "Service with id {0} doesn't exist.";
        public const string ServiceName = "Service with name already existed.";
        public const string ServiceNotFoundWithId = "Can not found service with id {0}.";
        public const string ServiceCarCategory = "Service with car category id {0} already existed.";
        public const string CarCategoryExist = "Car category with id {0} not found.";
        public const string CarPartExist = "Car part with id {0} not found.";
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
              public static ErrorsResult GetCategoryAlreadyExistError(Guid carCategoryId) =>
             new()
             {
                 Code = nameof(ServiceCarCategory),
                 Description = string.Format(ServiceCarCategory, carCategoryId)
             };
        public static ErrorsResult GetServiceNameUpdateAlreadyExistError(ServiceDtoForUpdate serviceDtoForUpdate) =>
             new()
             {
                 Code = nameof(ServiceName),
                 Description = string.Format(ServiceName, serviceDtoForUpdate.ServiceName)
             };
        public static ErrorsResult GetCarCategoryNotFoundError(Guid carCategory) =>
         new()
         {
             Code = nameof(CarCategoryExist),
             Description = string.Format(CarCategoryExist, carCategory)
         };
        public static ErrorsResult GetCarPartNotFoundError(Guid carCategory) =>
        new()
        {
            Code = nameof(CarCategoryExist),
            Description = string.Format(CarCategoryExist, carCategory)
        };

        #endregion
    }
}
