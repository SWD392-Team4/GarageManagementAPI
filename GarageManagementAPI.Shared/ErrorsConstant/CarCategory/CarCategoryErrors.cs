using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.CarCategory
{
    public class CarCategoryErrors
    {
        public const string CarCategoryNotfound = "Car category with id {0} not found.";

        public const string CarCategoryAlreadyExist = "Car category with name {0} alreadyExist.";

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
