using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule
{
    public record EmployeeScheduleDtoWithRelation : EmployeeScheduleDto
    {
        public virtual UserDto Employee { get; set; } = null!;
    }

}
