using GarageManagementAPI.Shared.Constant.Authentication;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForResetPasswordDto
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? Token { get; set; }
    }
}
