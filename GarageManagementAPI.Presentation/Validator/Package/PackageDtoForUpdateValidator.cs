using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.ErrorsConstant.Package;

namespace GarageManagementAPI.Presentation.Validator.Package
{
    public class PackageDtoForUpdateValidator : AbstractValidator<PackageDtoForUpdate>
    {
        public PackageDtoForUpdateValidator()
        {
            Include(new PackageDtoForManipulationValidator());
            AddRuleForStatus();
        }

        public void AddRuleForStatus()
        {
            RuleFor(p => p.Status)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.StatusRequired))
                .WithMessage(PackageErrors.StatusRequired)
                .Must(s => Enum.IsDefined(s!.GetType(), s))
                .WithErrorCode(nameof(PackageErrors.StatusInvalid))
                .WithMessage(PackageErrors.StatusInvalid);
        }
    }

}
