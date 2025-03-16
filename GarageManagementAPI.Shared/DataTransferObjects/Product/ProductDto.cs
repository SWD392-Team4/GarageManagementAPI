using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record class ProductDto : BaseDto<ProductDto>
    {
        public required Guid Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string Category { get; set; } = null!;
        public Guid BrandId { get; set; }
        public string? BrandImage { get; set; }
        public string BrandName { get; set; } = null!;
        public decimal? ProductPrice { get; set; }
        public List<string>? ImageLink { get; set; }
        public string? ProductDescription { get; set; }
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public int TotalQuantity { get; set; } = 1;

        public virtual ICollection<CarModelDto> CarModels { get; set; } = new List<CarModelDto>();

        public virtual ICollection<CarPartDto> CarParts { get; set; } = new List<CarPartDto>();
    }
}
