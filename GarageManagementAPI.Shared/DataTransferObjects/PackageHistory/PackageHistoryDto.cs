using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageHistory
{
    public record PackageHistoryDto : BaseDto<PackageHistoryDto>
    {
        public Guid? Id { get; set; }

        public Guid PackageId { get; set; }

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory ServiceCategory { get; set; }

        public Guid CarCategoryId { get; set; }

        public string Category { get; set; } = null!;

        public string PackageName { get; set; } = null!;

        public string Description { get; set; } = null!;

        [EnumDataType(typeof(PackageType))]
        public PackageType Type { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
