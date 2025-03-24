using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse
{
    public record class ProductAtWarehouseDto : BaseDto<ProductAtWarehouseDto>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; } 
        public string? ProductName { get; set; }
        public string? ProductBarcode { get; set; }
        public List<string> ProductImage { get; set; } = new List<string>();
        public string? BrandName { get; set; }
        public string? ProductCategoryName { get; set; }
        public Guid GoodsIssuedDetailId { get; set; }
        public decimal ProductPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public Guid GoodsReceivedDetailId { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus ProductStatus { get; set; }
    }
}
