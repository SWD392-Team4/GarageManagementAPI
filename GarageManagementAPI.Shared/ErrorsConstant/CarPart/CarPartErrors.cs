using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.CarPart
{
    public class CarPartErrors
    {
        #region CarPart const errors
        public const string CarPartNotFound = "Car Part with id {0} doesn't exist.";
        public const string CarPartName = "Car Part with name already existed.";
        public const string CarPartNameRequired = "The car part name is required.";
        public const string CarPartStatusRequired = "The car part status is required";
        public const string CarPartStatusInvalid = "Invalid car part status.";
        #endregion
        #region static method
        public static ErrorsResult GetCarPartNotFoundError() =>
            new()
            {
                Code = nameof(CarPartNotFound),
                Description = CarPartNotFound
            };
        public static ErrorsResult GetCarPartNotFoundWithIdError(Guid CarPartId) =>
            new()
            {
                Code = nameof(CarPartNotFound),
                Description = string.Format(CarPartNotFound, CarPartId)
            };
        public static ErrorsResult GetCarPartNameAlreadyExistError(CarPartDtoForCreation CarPartDtoForCreation) =>
             new()
             {
                 Code = nameof(CarPartName),
                 Description = string.Format(CarPartName, CarPartDtoForCreation.PartName)
             };
        public static ErrorsResult GetCarPartNameUpdateAlreadyExistError(CarPartDtoForUpdate CarPartDtoForUpdate) =>
             new()
             {
                 Code = nameof(CarPartName),
                 Description = string.Format(CarPartName, CarPartDtoForUpdate.PartName)
             };
        #endregion
    }
}
