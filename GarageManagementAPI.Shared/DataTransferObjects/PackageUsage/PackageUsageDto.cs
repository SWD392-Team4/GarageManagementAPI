using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageUsage
{
    public record PackageUsageDto
    {
        public Guid Id { get; set; }

        public Guid InvoiceAppointmentId { get; set; }

        public Guid PackageHistoryId { get; set; }

        public Guid CustomerCarId { get; set; }

        public int UsagedCount { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        [EnumDataType(typeof(PackageUsageStatus))]
        public PackageUsageStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
