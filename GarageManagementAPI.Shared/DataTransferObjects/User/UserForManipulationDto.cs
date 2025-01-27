namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForManipulationDto
    {
        public string? UserName { get; init; }

        public string? Password { get; init; }
    }
}
