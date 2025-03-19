using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule
{
    public record EmployeeScheduleDto : BaseDto<EmployeeScheduleDtoWithRelation>
    {
        public Guid Id { get; set; }
        public Guid AppointmentDetailId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        [EnumDataType(typeof(EmployeeScheduleStatus))]
        public EmployeeScheduleStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }

    public record EmployeeScheduleDtoWithRelation : EmployeeScheduleDto
    {

        public virtual AppointmentDetailDto AppointmentDetail { get; set; } = null!;

        public virtual UserDto Employee { get; set; } = null!;
    }

    public record EmployeeScheduleDtoForAssign
    {
        public Guid EmployeeId { get; set; }
    }

    public record EmployeeScheduleDtoForUnassign
    {
        public Guid EmployeeId { get; set; }

        public bool IsCancel { get; set; }

        public bool IsDecline { get; set; }
    }

    public record EmployeeScheduleDtoForStart
    {
        public DateTimeOffset EstimatedEndTime { get; set; }
    }

}
