using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.ErrorsConstant.PackageCondition;

namespace GarageManagementAPI.Presentation.Validator.PackageCondition
{
    public class PackageConditionDtoForManipulationValidator : AbstractValidator<PackageConditionDtoForManipulation>
    {
        public PackageConditionDtoForManipulationValidator()
        {
            AddRuleForConditionType();
            AddRuleForConditionValue();
        }
        private void AddRuleForConditionType()
        {
            RuleFor(p => p.ConditionType)
                .NotEmpty()
                .WithErrorCode(nameof(PackageConditionErrors.ConditionTypeRequired))
                .WithMessage(PackageConditionErrors.ConditionTypeRequired)
                .Must(ct => Enum.IsDefined(ct.GetType(), ct))
                .WithErrorCode(nameof(PackageConditionErrors.ConditionTypeInvalid))
                .WithMessage(PackageConditionErrors.ConditionTypeInvalid);
        }
        private void AddRuleForConditionValue()
        {
            RuleFor(p => p.ConditionValue)
                .NotEmpty()
                .WithErrorCode(nameof(PackageConditionErrors.ConditionValueRequired))
                .WithMessage(PackageConditionErrors.ConditionValueRequired);
        }
    }
}
