﻿using FluentValidation;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Presentation.Validator.User
{
    internal class UserForManipulationValidator : AbstractValidator<UserForManipulationDto>
    {
        public UserForManipulationValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage(UserErrors.UsernameRequired)
                .WithErrorCode(nameof(UserErrors.UsernameRequired))
                .Matches(@"^[a-zA-Z0-9_]+$")
                .WithMessage(UserErrors.UsernameContainSpecialCharacter)
                .WithErrorCode(nameof(UserErrors.UsernameContainSpecialCharacter));

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(UserErrors.PasswordRequired)
               .WithErrorCode(nameof(UserErrors.PasswordRequired));
        }
    }
}
