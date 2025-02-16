using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductImage
{
    public record class ProductImageDto : BaseDto<ProductImageDto>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Link { get; set; } = null!;

        [EnumDataType(typeof(ProductImageStatus))]
        public ProductImageStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
