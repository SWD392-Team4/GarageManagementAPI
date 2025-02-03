using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForRegistrationEmployeeDtoValidator : AbstractValidator<UserForRegistrationEmployeeDto>
    {
        public UserForRegistrationEmployeeDtoValidator()
        {
            AddUserNameRules();
            AddNameRules();
            AddEmailRules();
            AddPhoneNumberRules();
            AddRoleRules();
            AddWorkplaceIdRules();
            AddCitizenIdentificationRules();
        }

        // Username validation rules
        private void AddUserNameRules()
        {
            RuleFor(u => u.UserName)
                .MinimumLength(5)
                .WithMessage(UserErrors.UsernameTooShort)
                .WithErrorCode(nameof(UserErrors.UsernameTooShort))
                .MaximumLength(25)
                .WithMessage(UserErrors.UsernameTooLong)
                .WithErrorCode(nameof(UserErrors.UsernameTooLong));
        }

        // First and Last Name validation rules
        private void AddNameRules()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage(UserErrors.FirstNameRequired)
                .WithErrorCode(nameof(UserErrors.FirstNameRequired));

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage(UserErrors.LastNameRequired)
                .WithErrorCode(nameof(UserErrors.LastNameRequired));
        }

        // Email validation rules
        private void AddEmailRules()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(UserErrors.EmailRequired)
                .WithErrorCode(nameof(UserErrors.EmailRequired))
                .EmailAddress()
                .WithMessage(UserErrors.EmailInvalid)
                .WithErrorCode(nameof(UserErrors.EmailInvalid));
        }

        // Phone Number validation rules
        private void AddPhoneNumberRules()
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage(UserErrors.PhoneNumberRequired)
                .WithErrorCode(nameof(UserErrors.PhoneNumberRequired))
                .Matches(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)")
                .WithMessage(UserErrors.PhoneNumberInvalid)
                .WithErrorCode(nameof(UserErrors.PhoneNumberInvalid));
        }

        //Rule for CitizenIdentification
        private void AddCitizenIdentificationRules()
        {
            RuleFor(u => u.CitizenIdentification)
                .NotEmpty()
                .WithMessage(UserErrors.CitizenIdentificationRequied)
                .WithErrorCode(nameof(UserErrors.CitizenIdentificationRequied));
        }

        private void AddWorkplaceIdRules()
        {
            RuleFor(u => u.WorkplaceId)
               .NotEmpty()
               .WithMessage(UserErrors.WorkplaceIdRequired)
               .WithErrorCode(nameof(UserErrors.WorkplaceIdRequired));
        }

        // Role validation rules
        private void AddRoleRules()
        {
            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage(UserErrors.RoleRequired)
                .WithErrorCode(nameof(UserErrors.RoleRequired))
                .Must(ValidRole)
                .WithMessage(UserErrors.RoleInvalid)
                .WithErrorCode(nameof(UserErrors.RoleInvalid));
        }


        private bool ValidRole<T>(T role)
        {
            return Enum.IsDefined(typeof(T), role!);
        }

    }
}
