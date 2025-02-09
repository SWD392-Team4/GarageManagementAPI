using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Brand
{
    public class BrandErrors
    {
        #region Brandconst errors
        public const string BrandNotFound = "Work place with id {0} doesn't exist.";
        public const string BrandName = "Brand with name already existed.";
        public const string NameRequired = "The work place name is required.";
        public const string BrandStatusRequired = "The brand status is required";
        public const string BrandStatusInvalid = "Invalid brand status.";
        public const string BrandNotFoundWithId = "Can not found brand with id {0}.";
        #endregion

        #region static method
        public static ErrorsResult GetBrandNotFoundWithIdError()
        {
            return new()
            {
                Code = nameof(BrandNotFoundWithId),
                Description = BrandNotFoundWithId
            };
        }

        public static ErrorsResult GetBrandNotFoundError(Guid brandId) =>
    new()
    {
        Code = nameof(BrandNotFoundWithId),
        Description = string.Format(BrandNotFoundWithId, brandId)
    };

        public static ErrorsResult GetBrandNameAlreadyExistError(BrandDtoForCreation brandDtoForCreation)
        {

            return new()
            {
                Code = nameof(BrandName),
                Description = string.Format(BrandName, brandDtoForCreation.BrandName)
            };
        }
        #endregion
    }
}
