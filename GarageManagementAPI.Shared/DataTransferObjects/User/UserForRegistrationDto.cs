using GarageManagementAPI.Shared.Enum;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForRegistrationDto : UserForManipulationDto
    {
        public string? FirstName { get; init; }
        
        public string? LastName { get; init;}

        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        public SystemRole Role { get; init; }
    }
}
