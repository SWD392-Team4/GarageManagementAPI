using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    public class UserForConfirmEmailDtoValidator : AbstractValidator<UserForConfirmEmail>
    {
        public UserForConfirmEmailDtoValidator()
        {
            AddTokenRules();
            AddEmailRules();
        }

        private void AddTokenRules()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .WithErrorCode(nameof(UserErrors.TokenConfirmEmailRequired))
                .WithMessage(UserErrors.TokenConfirmEmailRequired);
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
