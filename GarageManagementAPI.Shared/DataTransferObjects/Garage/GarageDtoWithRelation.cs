using GarageManagementAPI.Shared.CustomAttribute;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;

namespace GarageManagementAPI.Shared.DataTransferObjects.Garage
{
    public record GarageDtoWithRelation : GarageDto
    {
        [PropertyOrder(6)]
        public IEnumerable<EmployeeDto>? Employees { get; init; }

    }
}
