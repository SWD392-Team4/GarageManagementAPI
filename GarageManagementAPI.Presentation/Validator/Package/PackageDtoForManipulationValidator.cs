using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.ErrorsConstant.Package;

namespace GarageManagementAPI.Presentation.Validator.Package
{
    public class PackageDtoForManipulationValidator : AbstractValidator<PackageDtoForManipulation>
    {
        public PackageDtoForManipulationValidator()
        {
            AddRuleForServiceCategory();
            AddRuleForCarCategoryId();
            AddRuleForPackageName();
            AddRuleForDescription();
            AddRuleForType();
            AddRuleForPackagePrice();
            AddRuleForValidityPeriod();
            AddRuleForTimeUnit();
            AddRuleForUsageLimit();
        }

        private void AddRuleForServiceCategory()
        {
            RuleFor(p => p.ServiceCategory)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.ServiceCategoryRequired))
                .WithMessage(PackageErrors.ServiceCategoryRequired)
                .Must(sc => Enum.IsDefined(sc!.GetType(), sc))
                .WithErrorCode(nameof(PackageErrors.ServiceCategoryInvalid))
                .WithMessage(PackageErrors.ServiceCategoryInvalid);
        }

        private void AddRuleForCarCategoryId()
        {
            RuleFor(p => p.CarCategoryId)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.CarCategoryIdRequired))
                .WithMessage(PackageErrors.CarCategoryIdRequired);
        }

        private void AddRuleForPackageName()
        {
            RuleFor(p => p.PackageName)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.PackageNameRequired))
                .WithMessage(PackageErrors.PackageNameRequired);
        }

        private void AddRuleForDescription()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.DescriptionRequired))
                .WithMessage(PackageErrors.DescriptionRequired);
        }

        private void AddRuleForType()
        {
            RuleFor(p => p.Type)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.TypeRequired))
                .WithMessage(PackageErrors.TypeRequired)
                .Must(t => Enum.IsDefined(t!.GetType(), t))
                .WithErrorCode(nameof(PackageErrors.TypeInvalid))
                .WithMessage(PackageErrors.TypeInvalid);
        }

        private void AddRuleForPackagePrice()
        {
            RuleFor(p => p.PackagePrice)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.PackagePriceRequired))
                .WithMessage(PackageErrors.PackagePriceRequired);
        }

        private void AddRuleForValidityPeriod()
        {
            RuleFor(p => p.ValidityPeriod)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.ValidityPeriodRequired))
                .WithMessage(PackageErrors.ValidityPeriodRequired);
        }

        private void AddRuleForTimeUnit()
        {
            RuleFor(p => p.TimeUnit)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.TimeUnitRequired))
                .WithMessage(PackageErrors.TimeUnitRequired)
                .Must(tu => Enum.IsDefined(tu!.GetType(), tu))
                .WithErrorCode(nameof(PackageErrors.TimeUnitInvalid))
                .WithMessage(PackageErrors.TimeUnitInvalid);
        }

        private void AddRuleForUsageLimit()
        {
            RuleFor(p => p.UsageLimit)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.UsageLimitRequired))
                .WithMessage(PackageErrors.UsageLimitRequired);
        }
    }

}
