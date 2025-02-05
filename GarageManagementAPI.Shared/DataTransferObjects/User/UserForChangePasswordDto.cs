namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForChangePasswordDto
    {
        public string? CurrentPassword { get; init; }

        public string? NewPassword { get; init; }

        public string? ConfirmNewPassword { get; init; }
    }
}
