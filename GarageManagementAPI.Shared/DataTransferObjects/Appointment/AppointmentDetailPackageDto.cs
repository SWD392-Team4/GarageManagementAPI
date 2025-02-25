using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDetailPackageDto
    {
        public Guid Id { get; set; }

        public Guid PackageHistoryId { get; set; }

        public string? PackageName { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid? UpdateByEmployeeId { get; set; }

        public string? UpdatedByEmployee { get; set; }

        public Guid? UpdateByCustomerId { get; set; }

        public string? UpdatedByCustomer { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }

        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus Status { get; set; }

        public int UsagedCount { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
