using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;

namespace GarageManagementAPI.Presentation.Validator.CarModel
{
    public class CarModelDtoForManipulationValidator : AbstractValidator<CarModelDtoForManipulation>
    {
        public CarModelDtoForManipulationValidator()
        {
            AddBrandIdRule();
            AddModelYearRule();
            AddModelNameRule();
            AddCarCategoryIdRule();
        }

        private void AddBrandIdRule()
        {
            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage(CarCategoryErrors.BrandIdRequired)
                .WithErrorCode(nameof(CarCategoryErrors.BrandIdRequired));
        }

        private void AddCarCategoryIdRule()
        {
            RuleFor(x => x.CarCategoryId)
                .NotEmpty().WithMessage(CarCategoryErrors.CarCategoryIdRequired)
                .WithErrorCode(nameof(CarCategoryErrors.CarCategoryIdRequired));
        }

        private void AddModelNameRule()
        {
            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage(CarCategoryErrors.ModelNameRequired)
                .WithErrorCode(nameof(CarCategoryErrors.ModelNameRequired));
        }

        private void AddModelYearRule()
        {
            RuleFor(x => x.ModelYear)
                .NotEmpty().WithMessage(CarCategoryErrors.ModelYearRequired)
                .WithErrorCode(nameof(CarCategoryErrors.ModelYearRequired));
        }
    }
}
