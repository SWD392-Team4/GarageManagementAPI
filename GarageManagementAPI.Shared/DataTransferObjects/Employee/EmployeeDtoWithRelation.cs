using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using System.Reflection;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{
    public record EmployeeDtoWithRelation : EmployeeDto
    {
        public GarageDto? Garage { get; init; }

    }

}
