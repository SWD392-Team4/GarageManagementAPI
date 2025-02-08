
using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;

namespace GarageManagementAPI.Presentation.Validator.Brand
{
    internal class BrandDtoForManipulationValidator : AbstractValidator<BrandDtoForManipulation>
    {
        public BrandDtoForManipulationValidator()
        {
            AddNameRules();
        }

        private void AddNameRules()
        {
            RuleFor(b => b.BrandName)
                .NotEmpty()
                .WithMessage(BrandErrors.NameRequired)
                .WithErrorCode(nameof(BrandErrors.NameRequired));
        }
    }
}
