using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDto
    {
        public Guid? Id { get; set; }

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory ServiceCategory { get; set; }

        public Guid CarCategoryId { get; set; }

        public string PackageName { get; set; } = null!;

        public string Description { get; set; } = null!;

        [EnumDataType(typeof(PackageType))]
        public PackageType Type { get; set; }

        [EnumDataType(typeof(PackageStatus))]
        public PackageStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }

    //public record PackageDtoWithRelation
    //{
    //    public CarCategory? CarCategory { get; set; }

    //    public ICollection<PackageCondition> PackageConditions { get; set; }

    //    public ICollection<PackageFeedBack> PackageFeedBacks { get; set; }

    //    public ICollection<PackageHistory> PackageHistories { get; set; }

    //    public ICollection<PackageImage> PackageImages { get; set; }
    //}
}
