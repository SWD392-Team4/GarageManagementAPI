using GarageManagementAPI.Shared.DataTransferObjects.Employee;

namespace GarageManagementAPI.Shared.DataTransferObjects.Garage
{
    public record GarageDtoWithRelation : GarageDto
    {
        public IEnumerable<EmployeeDto>? Employees { get; init; }

    }
}
