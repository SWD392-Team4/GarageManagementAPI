using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDto : BaseDto<AppointmentDto>
    {
        public Guid Id { get; set; }
        public Guid? ApproveByEmployeeId { get; set; }

        public Guid? CustomerId { get; set; }

        public string? ApproveByEmployee { get; set; }

        public Guid? RejectByEmployeeId { get; set; }

        public string? RejectByEmployee { get; set; }

        public Guid CarModelId { get; set; }

        public Guid GarageId { get; set; }

        public int? Mileage { get; set; }

        public string? VerificationCode { get; set; }

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

        public DateTimeOffset? CancelledAt { get; set; } // Thời gian hủy

        public DateTimeOffset? ApprovedAt { get; set; } // Thời gian duyệt

        public string? CarLicensePlateNumber { get; set; }

        public string? CanceledReason { get; set; } = "None";

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus? Status { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public IEnumerable<AppointmentDetailDto>? AppointmentDetails { get; set; }

        public IEnumerable<AppointmentDetailPackageDto>? AppointmentDetailPackages { get; set; }
    }
}
