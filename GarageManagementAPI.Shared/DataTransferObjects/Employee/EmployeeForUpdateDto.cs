using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{

    public record EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee status is required")]
        public required string Status { get; init; }

    }
}
