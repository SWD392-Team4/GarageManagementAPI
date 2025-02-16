using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Presentation.Validator.User
{
    public class UserForRegistrationDtoValidator : AbstractValidator<UserForRegistrationDto>
    {
        public UserForRegistrationDtoValidator()
        {
            Include(new UserForManipulationValidator());

            AddUserNameRules();
            AddNameRules();
            AddEmailRules();
            AddPasswordRules();
            AddConfirmPasswordRules();
            AddPhoneNumberRules();
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

        // Password validation rules
        private void AddPasswordRules()
        {
            RuleFor(x => x.Password)
                .MinimumLength(10)
                .WithMessage(UserErrors.PasswordTooShort)
                .WithErrorCode(nameof(UserErrors.PasswordTooShort))
                .MaximumLength(50)
                .WithMessage(UserErrors.PasswordTooLong)
                .WithErrorCode(nameof(UserErrors.PasswordTooLong))
                .Matches(@"[A-Z]+")
                .WithMessage(UserErrors.PasswordMissingUppercase)
                .WithErrorCode(nameof(UserErrors.PasswordMissingUppercase))
                .Matches(@"[a-z]+")
                .WithMessage(UserErrors.PasswordMissingLowercase)
                .WithErrorCode(nameof(UserErrors.PasswordMissingLowercase))
                .Matches(@"[0-9]+")
                .WithMessage(UserErrors.PasswordMissingDigit)
                .WithErrorCode(nameof(UserErrors.PasswordMissingDigit))
                .Matches(@"^(?=.*[\!\@\#\$\%\^\&\*\(\)_\+\-\=\[\]\{\}\|\;\:\'\""\,\.\<\>\?\/\\]).+$")
                .WithMessage(UserErrors.PasswordMissingSpecialCharacter)
                .WithErrorCode(nameof(UserErrors.PasswordMissingSpecialCharacter));
        }

        // Confirm Password validation rules
        private void AddConfirmPasswordRules()
        {
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage(UserErrors.ConfirmPasswordRequired)
                .WithErrorCode(nameof(UserErrors.ConfirmPasswordRequired))
                .Equal(x => x.Password)
                .WithMessage(UserErrors.ConfirmPasswordMismatch)
                .WithErrorCode(nameof(UserErrors.ConfirmPasswordMismatch));
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
    }
}
