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
                .WithMessage(WorkplaceErros.NameRequired)
                .WithErrorCode(nameof(WorkplaceErros.NameRequired));
        }

        private void AddPhoneNumberRules()
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage(WorkplaceErros.PhoneNumberRequired)
                .WithErrorCode(WorkplaceErros.PhoneNumberRequired)
                .Matches(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)")
                .WithMessage(WorkplaceErros.PhoneNumberInvalid)
                .WithErrorCode(nameof(WorkplaceErros.PhoneNumberInvalid));
        }

        private void AddAddressRules()
        {
            RuleFor(w => w.Address)
               .NotEmpty()
               .WithMessage(WorkplaceErros.AddressRequired)
               .WithErrorCode(nameof(WorkplaceErros.AddressRequired));
        }
        private void AddProvincesRules()
        {
            RuleFor(w => w.Province)
               .NotEmpty()
               .WithMessage(WorkplaceErros.ProvinceRequired)
               .WithErrorCode(nameof(WorkplaceErros.ProvinceRequired));
        }
        private void AddDistrictRules()
        {
            RuleFor(w => w.District)
               .NotEmpty()
               .WithMessage(WorkplaceErros.DistrictRequred)
               .WithErrorCode(nameof(WorkplaceErros.DistrictRequred));
        }
        private void AddWardRules()
        {
            RuleFor(w => w.Ward)
               .NotEmpty()
               .WithMessage(WorkplaceErros.WardRequired)
               .WithErrorCode(nameof(WorkplaceErros.WardRequired));
        }

        private void AddWorkplaceTypeRules()
        {
            RuleFor(w => w.WorkplaceType)
                .NotEmpty()
                .WithMessage(WorkplaceErros.WorkplaceTypeRequired)
                .WithErrorCode(nameof(WorkplaceErros.WorkplaceTypeRequired))
                .IsInEnum()
                .WithMessage(WorkplaceErros.WorkplaceTypeInvalid)
                .WithErrorCode(nameof(WorkplaceErros.WorkplaceTypeInvalid));

        }
    }
}
