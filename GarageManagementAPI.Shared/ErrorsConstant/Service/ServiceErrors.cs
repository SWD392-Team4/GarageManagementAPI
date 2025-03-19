using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Service
{
    public class ServiceErrors
    {
        #region Service const errors
        public const string ServiceNotFound = "Service with id {0} doesn't exist.";
        public const string ServiceName = "Service with name already existed.";
        public const string ServicesNotFoundWithIds = "Can not found any service with list id {0}.)";
        public const string ServicesFoundNotMatchWithIds = "Service found not match with list id {0}.)";
        public const string ServiceCarCategory = "Service with car category id {0} and car part id {1} and work nature and action already existed.";
        public const string CarCategoryExist = "Car category with id {0} not found.";
        public const string CarPartExist = "Car part with id {0} not found.";
        public const string ServiceByPackageHistoryIdNotFound = "Service with package history id {0} doesn't exist.";

        #endregion

        #region static method
        public static ErrorsResult GetServiceNotFoundWithIdError(IEnumerable<Guid> ids)
        {
            return new()
            {
                Code = nameof(ServicesNotFoundWithIds),
                Description = string.Format(ServicesNotFoundWithIds, ids)
            };
        }

        public static ErrorsResult GetServicesFoundNotMatchWithIdsError(IEnumerable<Guid> ids)
        {
            return new()
            {
                Code = nameof(ServicesFoundNotMatchWithIds),
                Description = string.Format(ServicesFoundNotMatchWithIds, string.Join(", ", ids))
            };
        }

        public static ErrorsResult GetServiceNotFoundError(Guid ServiceId) =>
            new()
            {
                Code = nameof(ServiceNotFound),
                Description = string.Format(ServiceNotFound, ServiceId)
            };

        public static ErrorsResult GetServiceNameAlreadyExistError(ServiceDtoForCreation serviceDtoForCreation) =>
             new()
             {
                 Code = nameof(ServiceName),
                 Description = string.Format(ServiceName, serviceDtoForCreation.ServiceName)
             };
        public static ErrorsResult GetCategoryAndCarPartAlreadyExistError(Guid carCategoryId, Guid carPartId, string workNature, string action) =>
       new()
       {
           Code = nameof(ServiceCarCategory),
           Description = string.Format(ServiceCarCategory, carCategoryId, carPartId)
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
            Code = nameof(CarPartExist),
            Description = string.Format(CarPartExist, carCategory)
        };

        public static ErrorsResult GetServiceByPackageHistoryIdNotFoundError(Guid packageHistoryId) =>
            new()
            {
                Code = nameof(ServiceByPackageHistoryIdNotFound),
                Description = string.Format(ServiceByPackageHistoryIdNotFound, packageHistoryId)
            };

        #endregion
    }
}
