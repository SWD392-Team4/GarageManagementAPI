namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record TokenDto
    {
        public required string AccessToken { get; init; }


        public required string RefreshToken { get; init; }
    }
}
