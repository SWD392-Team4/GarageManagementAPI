using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForChangePasswordDtoValidator : AbstractValidator<UserForChangePasswordDto>
    {
        public UserForChangePasswordDtoValidator()
        {
            AddCurrentPasswordRules();
            AddPasswordRules();
            AddConfirmPasswordRules();
        }

        private void AddPasswordRules()
        {
            RuleFor(x => x.NewPassword)
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

        private void AddCurrentPasswordRules()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .WithMessage(UserErrors.CurrentPasswordRequired)
                .WithErrorCode(nameof(UserErrors.CurrentPasswordRequired));
        }

        // Confirm Password validation rules
        private void AddConfirmPasswordRules()
        {
            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty()
                .WithMessage(UserErrors.ConfirmPasswordRequired)
                .WithErrorCode(nameof(UserErrors.ConfirmPasswordRequired))
                .Equal(x => x.NewPassword)
                .WithMessage(UserErrors.ConfirmPasswordMismatch)
                .WithErrorCode(nameof(UserErrors.ConfirmPasswordMismatch));
        }
    }
}
