using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    public class UserForResetPasswordDtoValidator : AbstractValidator<UserForResetPasswordDto>
    {
        public UserForResetPasswordDtoValidator()
        {
            AddPasswordRules();
            AddConfirmPasswordRules();
            AddTokenRules();
            AddEmailRules();
        }

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
                .Matches(@"[\!\?\*\.]+")
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

        private void AddTokenRules()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .WithErrorCode(nameof(UserErrors.TokenResetPasswordRequired))
                .WithMessage(UserErrors.TokenResetPasswordRequired);
        }

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
    }
}
