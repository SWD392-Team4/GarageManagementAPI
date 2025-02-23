using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.CarPartCategoryCategory
{
    public class CarPartCategoryErrors
    {
        #region CarPartCategory const errors
        public const string CarPartCategoryNotFound = "Car part category with id {0} doesn't exist.";
        public const string CarPartCategoryName = "Car part category with name already existed.";
        public const string CarPartCategoryNameRequired = "The car part category name is required.";
        public const string CarPartCategoryStatusRequired = "The Car part category status is required";
        public const string CarPartCategoryStatusInvalid = "Invalid car part category status.";
        #endregion
        #region static method
        public static ErrorsResult GetCarPartCategoryNotFoundError() =>
            new()
            {
                Code = nameof(CarPartCategoryNotFound),
                Description = CarPartCategoryNotFound
            };
        public static ErrorsResult GetCarPartCategoryNotFoundWithIdError(Guid carPartCategoryId) =>
            new()
            {
                Code = nameof(CarPartCategoryNotFound),
                Description = string.Format(CarPartCategoryNotFound, carPartCategoryId)
            };
        public static ErrorsResult GetCarPartCategoryNameAlreadyExistError(CarPartCategoryDtoForCreation carPartCategoryDtoForCreation) =>
             new()
             {
                 Code = nameof(CarPartCategoryName),
                 Description = string.Format(CarPartCategoryName, carPartCategoryDtoForCreation.PartCategory)
             };
        public static ErrorsResult GetCarPartCategoryNameUpdateAlreadyExistError(CarPartCategoryDtoForUpdate carPartCategoryDtoForUpdate) =>
             new()
             {
                 Code = nameof(CarPartCategoryName),
                 Description = string.Format(CarPartCategoryName, carPartCategoryDtoForUpdate.PartCategory)
             };
        #endregion
    }
}
