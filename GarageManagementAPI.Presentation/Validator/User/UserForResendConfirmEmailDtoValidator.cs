using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForResendConfirmEmailDtoValidator : AbstractValidator<UserForResendConfirmEmailDto>
    {
        public UserForResendConfirmEmailDtoValidator()
        {
            AddEmailRules();
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
