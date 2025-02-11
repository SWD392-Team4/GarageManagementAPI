namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForUpdateDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
