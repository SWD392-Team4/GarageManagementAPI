using GarageManagementAPI.Shared.Constant.Authentication;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForForgotPasswordDto
    {
        [Required(ErrorMessage = UserErrors.EmailRequired)]
        [EmailAddress(ErrorMessage = UserErrors.EmailInvalid)]
        public string? Email { get; set; }
    }
}
