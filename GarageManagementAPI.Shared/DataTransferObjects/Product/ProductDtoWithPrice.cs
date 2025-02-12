using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDtoWithPrice : BaseDto<ProductDtoWithPrice>
    {
        public required Guid? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBarcode { get; set; }
        public string? ProductDescription { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public decimal? ProductPrice { get; set; }
    }
}
