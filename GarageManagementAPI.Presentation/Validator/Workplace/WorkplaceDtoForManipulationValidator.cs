using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;

namespace GarageManagementAPI.Presentation.Validator.Workplace
{
    internal class WorkplaceDtoForManipulationValidator : AbstractValidator<WorkplaceDtoForManipulation>
    {
        public WorkplaceDtoForManipulationValidator()
        {
            AddNameRules();
            AddPhoneNumberRules();
            AddAddressRules();
            AddProvincesRules();
            AddDistrictRules();
            AddWardRules();
            AddWorkplaceTypeRules();
        }
        private void AddNameRules()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage(WorkplaceErrors.NameRequired)
                .WithErrorCode(nameof(WorkplaceErrors.NameRequired));
        }

        private void AddPhoneNumberRules()
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage(WorkplaceErrors.PhoneNumberRequired)
                .WithErrorCode(WorkplaceErrors.PhoneNumberRequired)
                .Matches(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)")
                .WithMessage(WorkplaceErrors.PhoneNumberInvalid)
                .WithErrorCode(nameof(WorkplaceErrors.PhoneNumberInvalid));
        }

        private void AddAddressRules()
        {
            RuleFor(w => w.Address)
               .NotEmpty()
               .WithMessage(WorkplaceErrors.AddressRequired)
               .WithErrorCode(nameof(WorkplaceErrors.AddressRequired));
        }
        private void AddProvincesRules()
        {
            RuleFor(w => w.Province)
               .NotEmpty()
               .WithMessage(WorkplaceErrors.ProvinceRequired)
               .WithErrorCode(nameof(WorkplaceErrors.ProvinceRequired));
        }
        private void AddDistrictRules()
        {
            RuleFor(w => w.District)
               .NotEmpty()
               .WithMessage(WorkplaceErrors.DistrictRequred)
               .WithErrorCode(nameof(WorkplaceErrors.DistrictRequred));
        }
        private void AddWardRules()
        {
            RuleFor(w => w.Ward)
               .NotEmpty()
               .WithMessage(WorkplaceErrors.WardRequired)
               .WithErrorCode(nameof(WorkplaceErrors.WardRequired));
        }

        private void AddWorkplaceTypeRules()
        {
            RuleFor(w => w.WorkplaceType)
                .NotEmpty()
                .WithMessage(WorkplaceErrors.WorkplaceTypeRequired)
                .WithErrorCode(nameof(WorkplaceErrors.WorkplaceTypeRequired))
                .IsInEnum()
                .WithMessage(WorkplaceErrors.WorkplaceTypeInvalid)
                .WithErrorCode(nameof(WorkplaceErrors.WorkplaceTypeInvalid));

        }
    }
}
