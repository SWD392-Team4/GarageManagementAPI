namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForForgotPasswordDto
    {
        public string? Email { get; init; }
    }
}
