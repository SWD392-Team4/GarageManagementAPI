namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record TokenDto
    {
        public string? AccessToken { get; init; }


        public string? RefreshToken { get; init; }
    }
}
