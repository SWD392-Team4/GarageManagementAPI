
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForRegistrationDto : UserForManipulationDto
    {
        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        [EnumDataType(typeof(SystemRole), ErrorMessage = UserErrors.RoleInvalid)]
        public SystemRole Role { get; init; }

        public string? ConfirmPassword { get; init; }
    }
}
