using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;

namespace GarageManagementAPI.Presentation.Validator.CarCategory
{
    internal class CarCategoryDtoForManipulationValidator : AbstractValidator<CarCategoryDtoForManipulation>
    {
        public CarCategoryDtoForManipulationValidator()
        {
            AddCategoryRules();
            AddDescriptionRules();
        }

        private void AddCategoryRules()
        {
            RuleFor(e => e.Category)
                .NotEmpty()
                .WithErrorCode(nameof(CarCategoryErrors.CarCategoryNameRequired))
                .WithMessage(CarCategoryErrors.CarCategoryNameRequired);
        }

        private void AddDescriptionRules()
        {
            RuleFor(e => e.Description)
                .NotEmpty()
                .WithErrorCode(nameof(CarCategoryErrors.CarCategoryDescriptionRequired))
                .WithMessage(CarCategoryErrors.CarCategoryDescriptionRequired);
        }
    }
}
