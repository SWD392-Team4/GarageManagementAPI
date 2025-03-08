using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.CarCategory
{
    public class CarCategoryErrors
    {
        public const string BrandIdRequired = "Brand id is required.";
        public const string CarCategoryIdRequired = "Car category id is required.";
        public const string ModelNameRequired = "Model name is required.";
        public const string ModelYearRequired = "Model year is required.";
        public const string CarModelStatusRequired = "Car model status is required.";
        public const string CarModelStatusInvalid = "Car model status is invalid.";

        public const string CarCategoryNotfound = "Car category with id {0} not found.";

        public const string CarCategoryAlreadyExist = "Car category with name {0} alreadyExist.";

        public const string CarCategoryNameRequired = "Car category name is required.";
        public const string CarCategoryDescriptionRequired = " Car category descrtiption is required.";
        public const string CarCategoryStatusRequired = "Car category status is required.";
        public const string CarCategoryStatusInvalid = "Car category status is invalid.";

        public static ErrorsResult GetCarCategoryNotFoundError(Guid id)
            => new()
            {
                Code = nameof(CarCategoryNotfound),
                Description = string.Format(CarCategoryNotfound, id)
            };

        public static ErrorsResult GetCarCategoryAlreadyExist(string name)
            => new()
            {
                Code = nameof(CarCategoryAlreadyExist),
                Description = string.Format(CarCategoryAlreadyExist, name)
            };
    }
}
