using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;

namespace GarageManagementAPI.Presentation.Validator.CarCategory
{
    internal class CarCategoryDtoForCreateValidator : AbstractValidator<CarCategoryDtoForCreate>
    {
        public CarCategoryDtoForCreateValidator()
        {
            Include(new CarCategoryDtoForManipulationValidator());
        }
    }
}
