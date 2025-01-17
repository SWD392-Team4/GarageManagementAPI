using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{
    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is required")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "Employee phonenumber is required")]
        public required string? PhoneNumber { get; init; }

        [Required(ErrorMessage = "Employee address is required")]
        public required string? Address { get; init; }

        public DateOnly DateOfBirth { get; init; }

        public bool Gender { get; init; }

        [Required(ErrorMessage = "Employee citizen identification is required")]
        public required string? CitizenIdentification { get; init; }

        [Required(ErrorMessage = "Employee email is required")]
        public required string Email { get; init; }

        [EnumDataType(typeof(SystemRole))]
        [Required(ErrorMessage = "Employee role is required")]
        public SystemRole Role { get; init; }

    }
}
