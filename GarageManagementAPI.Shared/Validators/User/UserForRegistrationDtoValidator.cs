using FluentValidation;
using GarageManagementAPI.Shared.Constant;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Shared.Validators.User
{
    public class UserForRegistrationDtoValidator : AbstractValidator<UserForRegistrationDto>
    {
        public UserForRegistrationDtoValidator()
        {
            AddUserNameRules();
            AddNameRules();
            AddEmailRules();
            AddPasswordRules();
            AddConfirmPasswordRules();
            AddPhoneNumberRules();
            AddRoleRules();
        }

        // Username validation rules
        private void AddUserNameRules()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage(UserErrorMessages.UsernameRequired)
                .WithErrorCode(nameof(UserErrorMessages.UsernameRequired))
                .MinimumLength(5)
                .WithMessage(UserErrorMessages.UsernameTooShort)
                .WithErrorCode(nameof(UserErrorMessages.UsernameTooShort))
                .MaximumLength(25)
                .WithMessage(UserErrorMessages.UsernameTooLong)
                .WithErrorCode(nameof(UserErrorMessages.UsernameTooLong));
        }

        // First and Last Name validation rules
        private void AddNameRules()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage(UserErrorMessages.FirstNameRequired)
                .WithErrorCode(nameof(UserErrorMessages.FirstNameRequired));

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage(UserErrorMessages.LastNameRequired)
                .WithErrorCode(nameof(UserErrorMessages.LastNameRequired));
        }

        // Email validation rules
        private void AddEmailRules()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(UserErrorMessages.EmailRequired)
                .WithErrorCode(nameof(UserErrorMessages.EmailRequired))
                .EmailAddress()
                .WithMessage(UserErrorMessages.EmailInvalid)
                .WithErrorCode(nameof(UserErrorMessages.EmailInvalid));
        }

        // Password validation rules
        private void AddPasswordRules()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(UserErrorMessages.PasswordRequired)
                .WithErrorCode(nameof(UserErrorMessages.PasswordRequired))
                .MinimumLength(10)
                .WithMessage(UserErrorMessages.PasswordTooShort)
                .WithErrorCode(nameof(UserErrorMessages.PasswordTooShort))
                .MaximumLength(50)
                .WithMessage(UserErrorMessages.PasswordTooLong)
                .WithErrorCode(nameof(UserErrorMessages.PasswordTooLong))
                .Matches(@"[A-Z]+")
                .WithMessage(UserErrorMessages.PasswordMissingUppercase)
                .WithErrorCode(nameof(UserErrorMessages.PasswordMissingUppercase))
                .Matches(@"[a-z]+")
                .WithMessage(UserErrorMessages.PasswordMissingLowercase)
                .WithErrorCode(nameof(UserErrorMessages.PasswordMissingLowercase))
                .Matches(@"[0-9]+")
                .WithMessage(UserErrorMessages.PasswordMissingDigit)
                .WithErrorCode(nameof(UserErrorMessages.PasswordMissingDigit))
                .Matches(@"[\!\?\*\.]+")
                .WithMessage(UserErrorMessages.PasswordMissingSpecialCharacter)
                .WithErrorCode(nameof(UserErrorMessages.PasswordMissingSpecialCharacter));
        }

        // Confirm Password validation rules
        private void AddConfirmPasswordRules()
        {
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage(UserErrorMessages.ConfirmPasswordRequired)
                .WithErrorCode(nameof(UserErrorMessages.ConfirmPasswordRequired))
                .Equal(x => x.Password)
                .WithMessage(UserErrorMessages.ConfirmPasswordMismatch)
                .WithErrorCode(nameof(UserErrorMessages.ConfirmPasswordMismatch));
        }

        // Phone Number validation rules
        private void AddPhoneNumberRules()
        {
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage(UserErrorMessages.PhoneNumberRequired)
                .WithErrorCode(nameof(UserErrorMessages.PhoneNumberRequired))
                .Matches(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)")
                .WithMessage(UserErrorMessages.PhoneNumberInvalid)
                .WithErrorCode(nameof(UserErrorMessages.PhoneNumberInvalid));
        }

        // Role validation rules
        private void AddRoleRules()
        {
            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage(UserErrorMessages.RoleRequired)
                .WithErrorCode(nameof(UserErrorMessages.RoleRequired))
                .Must(SystemRole.ValidRole)
                .WithMessage(UserErrorMessages.RoleInvalid)
                .WithErrorCode(nameof(UserErrorMessages.RoleInvalid));
        }
    }

}
