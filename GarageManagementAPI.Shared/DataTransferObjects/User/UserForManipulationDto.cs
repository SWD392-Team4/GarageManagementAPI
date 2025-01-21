using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.User
{
    public record UserForManipulationDto 
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; init; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}
