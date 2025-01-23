
namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForRegistrationDto : UserForManipulationDto
    {
        public required string FirstName { get; init; }

        public required string LastName { get; init; }

        public required string Email { get; init; }

        public required string PhoneNumber { get; init; }

        public required string Role { get; init; }

        public required string ConfirmPassword { get; init; }
    }
}
