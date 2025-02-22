using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Brand
{
    public class BrandErrors
    {
        #region Brand const errors
        public const string BrandNotFound = "Brand with id {0} doesn't exist.";
        public const string BrandName = "Brand with name already existed.";
        public const string NameRequired = "The brand name is required.";
        public const string BrandStatusRequired = "The brand status is required";
        public const string BrandStatusInvalid = "Invalid brand status.";
        #endregion

        #region static method
        public static ErrorsResult GetBrandNotFoundError() =>
            new()
            {
                Code = nameof(BrandNotFound),
                Description = BrandNotFound
            };
        public static ErrorsResult GetBrandNotFoundWithIdError(Guid brandId) =>
            new()
             {
                Code = nameof(BrandNotFound),
                Description = string.Format(BrandNotFound, brandId)
            };
        public static ErrorsResult GetBrandNameAlreadyExistError(BrandDtoForCreation brandDtoForCreation) =>
             new()
             {
                 Code = nameof(BrandName),
                 Description = string.Format(BrandName, brandDtoForCreation.BrandName)
             };
        public static ErrorsResult GetBrandNameUpdateAlreadyExistError(BrandDtoForUpdate brandDtoForUpdate) =>
             new()
             {
                 Code = nameof(BrandName),
                 Description = string.Format(BrandName, brandDtoForUpdate.BrandName)
             };
        #endregion
    }
}
