using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForManipulationDto
    {
        [Required(ErrorMessage = "Username is required")]
        public required string UserName { get; init; }


        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; init; }
    }
}
