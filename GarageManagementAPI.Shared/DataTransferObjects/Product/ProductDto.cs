using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;


namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDto : BaseDto<ProductDto>
    {
        public Guid Id {get; set; }
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public required string ProductDescription { get; set; }
        public Guid BrandId { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
