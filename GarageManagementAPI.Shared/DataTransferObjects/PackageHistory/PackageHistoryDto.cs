using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageHistory
{
    public record PackageHistoryDto : BaseDto<PackageHistoryDto>
    {
        public Guid Id { get; set; }

        public Guid PackageId { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }

        [EnumDataType(typeof(PackageHistoryStatus))]
        public PackageHistoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
