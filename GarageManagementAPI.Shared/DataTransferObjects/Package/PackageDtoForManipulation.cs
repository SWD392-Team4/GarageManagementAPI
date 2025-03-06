using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDtoForManipulation
    {
        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory? ServiceCategory { get; set; }

        public Guid? CarCategoryId { get; set; }

        public string? PackageName { get; set; }

        public string? Description { get; set; }

        [EnumDataType(typeof(PackageType))]
        public PackageType? Type { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }
    }
}
