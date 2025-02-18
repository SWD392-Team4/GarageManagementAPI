using FluentValidation;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Presentation.Validator.Brand
{
    internal class BrandDtoForUpdateValidator : AbstractValidator<BrandDtoForUpdate>
    {
        public BrandDtoForUpdateValidator()
        {
            Include(new BrandDtoForManipulationValidator());
            AddStatusRules();
        }

        private void AddStatusRules()
        {
            RuleFor(b => b.Status)
               .NotEmpty()
               .WithMessage(BrandErrors.BrandStatusRequired)
               .WithErrorCode(nameof(BrandErrors.BrandStatusRequired))
               .Must(status => Enum.IsDefined(typeof(BrandStatus), status))
                .WithMessage(BrandErrors.BrandStatusInvalid)
                .WithErrorCode(nameof(BrandErrors.BrandStatusInvalid));
        }

    }
}
