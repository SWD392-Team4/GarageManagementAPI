using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDtoFull : BaseDto<ProductDtoFull>
    {
        public required Guid Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public required string ProductDescription { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public decimal? ProductPrice { get; set; }

        public string? ProductImg { get; set; }
    }
}
