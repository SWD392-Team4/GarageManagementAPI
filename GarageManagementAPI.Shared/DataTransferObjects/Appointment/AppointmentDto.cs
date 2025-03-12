using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDto : BaseDto<AppointmentDto>
    {
        public Guid Id { get; set; }
        public Guid? ApproveByEmployeeId { get; set; }

        public Guid CarModelId { get; set; }

        public Guid GarageId { get; set; }

        public int? Mileage { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public string? CustomerEmail { get; set; }

        public DateTimeOffset EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? ActualAppointmentTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        public decimal Price { get; set; }

        [EnumDataType(typeof(AppointmentType))]
        public AppointmentType? AppointmentType { get; set; }

        public string? CarLicensePlateNumber { get; set; }

        public string? CanceledReason { get; set; } = "None";

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus? Status { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
