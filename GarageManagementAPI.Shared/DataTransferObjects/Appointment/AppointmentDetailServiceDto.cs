using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDetailServiceDto
    {
        public Guid Id { get; set; }

        public string? ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public Guid ServiceHistoryId { get; set; }

        public decimal Price { get; set; }

        public Guid? UpdateByEmployeeId { get; set; }

        public string? UpdatedByEmployee { get; set; }

        public Guid? UpdateByCustomerId { get; set; }

        public string? UpdatedByCustomer { get; set; }

        public Guid EmployeeInChargeId { get; set; }

        public string? EmployeeInCharge { get; set; }

        public string? ServiceNote { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus Status { get; set; }

        public DateTimeOffset CreateAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }

}
