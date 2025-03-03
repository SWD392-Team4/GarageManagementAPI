using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record class BrandDto : BaseDto<BrandDto>
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = null!;
        public string ImageLink { get; set; } = null!;

        [EnumDataType(typeof(BrandStatus))]
        public BrandStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
