using GarageManagementAPI.Shared.CustomAttribute;
using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{

    public record EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        [EnumDataType(typeof(EmployeeStatus))]
        [Required(ErrorMessage = "Employee status is required")]
        public EmployeeStatus Status { get; init; }

    }
}
