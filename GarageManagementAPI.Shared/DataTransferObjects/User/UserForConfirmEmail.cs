using GarageManagementAPI.Shared.Constant.Authentication;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForConfirmEmail
    {
        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}
