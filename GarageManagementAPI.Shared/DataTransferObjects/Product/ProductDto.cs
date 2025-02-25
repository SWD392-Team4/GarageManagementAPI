using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDto : BaseDto<ProductDto>
    {
        public required Guid Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public string Category { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public decimal? ProductPrice { get; set; }
        public List<string>? ImageLink { get; set; }
        public string? ProductDescription { get; set; }
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
