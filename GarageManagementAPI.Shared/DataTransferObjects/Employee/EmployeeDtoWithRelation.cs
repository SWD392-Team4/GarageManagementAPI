using GarageManagementAPI.Shared.CustomAttribute;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using System.Reflection;
using System.Text.Json.Serialization;

namespace GarageManagementAPI.Shared.DataTransferObjects.Employee
{
    public record EmployeeDtoWithRelation : EmployeeDto
    {
        [PropertyOrder(12)]
        public GarageDto? Garage { get; init; }

    }

}
