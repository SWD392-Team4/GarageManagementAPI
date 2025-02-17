using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForUpdateEmployeeDtoValidator : AbstractValidator<UserForUpdateEmployeeDto>
    {
        public UserForUpdateEmployeeDtoValidator()
        {
            Include(new UserForUpdateDtoValidator());
            RuleFor(u => u.DateOfBirth)
                 .NotEmpty()
                 .WithErrorCode(nameof(UserErrors.DateOfBirthRequired))
                 .WithMessage(UserErrors.DateOfBirthRequired);

            RuleFor(u => u.CitizenIdentification)
                 .NotEmpty()
                 .WithErrorCode(nameof(UserErrors.CitizenIdentificationRequied))
                 .WithMessage(UserErrors.CitizenIdentificationRequied)
                 .Matches(@"[0-9]+")
                 .WithMessage(UserErrors.CitizenIdentificationInvalid)
                 .WithErrorCode(nameof(UserErrors.CitizenIdentificationInvalid));

            RuleFor(u => u.WorkplaceId)
              .NotEmpty()
              .WithMessage(UserErrors.WorkplaceIdRequired)
              .WithErrorCode(nameof(UserErrors.WorkplaceIdRequired));

            RuleFor(u => u.Gender)
              .NotEmpty()
              .WithMessage(UserErrors.GenderRequired)
              .WithErrorCode(nameof(UserErrors.GenderRequired));


            RuleFor(u => u.Status)
                .NotEmpty()
                .WithMessage(UserErrors.UserStatusRequired)
                .WithErrorCode(nameof(UserErrors.UserStatusRequired))
                .Must(u => Enum.IsDefined(typeof(UserStatus), u))
                .WithMessage(UserErrors.UserStatusInvalid)
                .WithErrorCode(nameof(UserErrors.UserStatusInvalid));
        }


    }
}
