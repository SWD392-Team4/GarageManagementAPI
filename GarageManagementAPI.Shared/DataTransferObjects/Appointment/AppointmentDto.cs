using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDto
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; } = "None";
        public string GarageName { get; set; } = "None";

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; set; }

        public string CustomerName { get; set; } = "None";

        public string CustomerPhoneNumber { get; set; } = "None";

        public string CustomerEmail { get; set; } = "None";

        public string CarModelName { get; set; } = "None";

        public int Mileage { get; set; }

        public string CarLicensePlateNumber { get; set; } = "None";

        public string CarCondition { get; set; } = "None";

        public string? CanceledReason { get; set; } = "None";

        public DateTimeOffset? EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? ActualAppointmentTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }
        public decimal Price { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [EnumDataType(typeof(AppointmentType))]
        public AppointmentType AppointmentType { get; set; }
    }

    public record AppointmentDtoForCreate
    {
        public Guid CarModelId { get; set; }

        public Guid GarageId { get; set; }

        public int Mileage { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public DateTimeOffset EstimatedAppointmentTime { get; set; }

        public DateTimeOffset EstimatedEndTime { get; set; }

        public decimal Price { get; set; }

        public IList<Guid>? PackageList { get; set; }

        public IList<AppointmentDetailDtoForCreate>? ServiceList { get; set; }

    }

    public record AppointmentDetailDtoForCreate
    {
        public Guid ServiceHistoryId { get; set; }

        public IList<AppointmentReplacementPartDtoForCreate>? ReplacementParts { get; set; }
    }

    public record AppointmentReplacementPartDtoForCreate
    {
        public Guid ProductHistoryId { get; set; }

        public int Quantity { get; set; }
    }
}
