namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForManipulationDto
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
