using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDto : BaseDto<PackageDto>
    {
        public Guid? Id { get; set; }

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory? ServiceCategory { get; set; }

        public Guid? CarCategoryId { get; set; }

        public string? Category { get; set; }

        public string? PackageName { get; set; }

        public string? Description { get; set; }

        [EnumDataType(typeof(PackageType))]
        public PackageType? Type { get; set; }

        [EnumDataType(typeof(PackageStatus))]
        public PackageStatus? Status { get; set; }

        public decimal? PackagePrice { get; set; }

        public int? ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit? TimeUnit { get; set; }

        public int? UsageLimit { get; set; }

        public IEnumerable<PackageImageDto>? PackageImages { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
