using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;

namespace GarageManagementAPI.Presentation.Validator.CarCategory
{
    internal class CarCategoryDtoForUpdateValidator : AbstractValidator<CarCategoryDtoForUpdate>
    {
        public CarCategoryDtoForUpdateValidator()
        {
            Include(new CarCategoryDtoForManipulationValidator());
            AddRuleForStatus();
        }

        private void AddRuleForStatus()
        {
            RuleFor(e => e.Status).NotEmpty()
                .WithErrorCode(nameof(CarCategoryErrors.CarCategoryStatusRequired))
                .WithMessage(CarCategoryErrors.CarCategoryStatusRequired)
                .Must(status => Enum.IsDefined(typeof(CarCategoryStatus), status))
                .WithErrorCode(nameof(CarCategoryErrors.CarCategoryStatusInvalid))
                .WithMessage(CarCategoryErrors.CarCategoryStatusInvalid);
        }
    }
}
