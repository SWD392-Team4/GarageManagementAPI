using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForUpdateDtoValidator : AbstractValidator<UserForUpdateDto>
    {
        public UserForUpdateDtoValidator()
        {
            RuleFor(u => u.FirstName)
                 .NotEmpty()
                 .WithErrorCode(nameof(UserErrors.FirstNameRequired))
                 .WithMessage(UserErrors.FirstNameRequired);

            RuleFor(x => x.LastName)
                .NotEmpty()
                 .WithErrorCode(nameof(UserErrors.LastNameRequired))
                 .WithMessage(UserErrors.LastNameRequired);
        }
    }
}
