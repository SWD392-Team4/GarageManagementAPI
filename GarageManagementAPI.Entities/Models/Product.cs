using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Product : BaseEntity<Product>
    {
        public Guid BrandId { get; set; }

        public Guid ProductCategoryId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductBarcode { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        [EnumDataType(typeof(SystemStatus))]
        public ProductStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Brand Brand { get; set; } = null!;

        public virtual ICollection<GoodsReceivedDetail> GoodsReceivedDetails { get; set; } = new List<GoodsReceivedDetail>();

        public virtual ProductCategory ProductCategory { get; set; } = null!;

        public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<CarPart> CarParts { get; set; } = new List<CarPart>();
    }

}

