using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.CarModel
{
    public class CarModelErrors
    {
        public const string CarModelNotFound = "Car model with id {0} not found.";
        public const string CarModelExist = "Car model with name {0} and year {0} in category {0} of brand {0} already exist";

        public static ErrorsResult GetCarModelNotFoundError(Guid id)
            => new()
            {
                Code = nameof(CarModelNotFound),
                Description = string.Format(CarModelNotFound, id)
            };

        public static ErrorsResult GetCarModelExist(string name, DateOnly year, Guid category, Guid brandName)
             => new()
             {
                 Code = nameof(CarModelExist),
                 Description = string.Format(CarModelExist, name, year, category, brandName)
             };
    }
}
