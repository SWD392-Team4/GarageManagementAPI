using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.ErrorsConstant.Package;

namespace GarageManagementAPI.Presentation.Validator.Package
{
    public class PackageDtoForCreationValidator : AbstractValidator<PackageDtoForCreation>
    {
        public PackageDtoForCreationValidator(IValidator<PackageConditionDtoForCreation> packageConditionValidator)
        {

            Include(new PackageDtoForManipulationValidator());

            AddRuleForServiceList();
            AddRuleForPackageConditions();

            RuleForEach(p => p.PackageConditions)
                .SetValidator(packageConditionValidator);
        }

        private void AddRuleForServiceList()
        {
            RuleFor(p => p.ServiceList)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.ServiceListRequired))
                .WithMessage(PackageErrors.ServiceListRequired);
        }

        private void AddRuleForPackageConditions()
        {
            RuleFor(p => p.PackageConditions)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.PackageConditionsRequired))
                .WithMessage(PackageErrors.PackageConditionsRequired);
        }
    }

}
