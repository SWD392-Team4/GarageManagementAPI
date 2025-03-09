using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class PackageHistoryParameters : RequestParameters
    {
        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory? ServiceCategory { get; set; }

        public Guid? CarCategoryId { get; set; }

        public string? PackageName { get; set; }

        public string? Description { get; set; }

        [EnumDataType(typeof(PackageType))]
        public PackageType? Type { get; set; }

        public decimal? PackagePrice { get; set; }

        public int? ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit? TimeUnit { get; set; }

        public int? UsageLimit { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public decimal MinPrice { get; set; } = 0;

        public decimal MaxPrice { get; set; } = int.MaxValue;

        public bool ValidatePriceRange => MinPrice < MaxPrice;
    }
}
