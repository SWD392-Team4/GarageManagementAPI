using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Garage
{
    public abstract record GarageForManipulationDto
    {
        [Required(ErrorMessage = "Garage name is required")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "Garage address is required")]
        public required string Address { get; init; }

        [Required(ErrorMessage = "Garage city is required")]
        public required string City { get; init; }

        [Required(ErrorMessage = "Garage phonenumber is required")]
        public required string PhoneNumber { get; init; }
    }
}
