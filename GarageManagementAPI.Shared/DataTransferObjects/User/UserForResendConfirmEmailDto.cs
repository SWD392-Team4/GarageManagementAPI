namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForResendConfirmEmailDto
    {
        public string? Email { get; init; }
    }
}
