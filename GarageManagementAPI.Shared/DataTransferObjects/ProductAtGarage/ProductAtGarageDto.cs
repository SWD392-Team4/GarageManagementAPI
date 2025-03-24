using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage
{
    public record class ProductAtGarageDto : BaseDto<ProductAtGarageDto>
    {
        public Guid Id {  get; set; } 
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<string> ProductImage { get; set; } = new List<string>();
        public string? BrandName { get; set; }
        public string? ProductCategoryName { get; set; }

        public string? ProductDescription { get; set; }
        public Guid GoodsIssuedDetailId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductBarcodeAtGarage { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus ProductStatus { get; set; }

    }
}
