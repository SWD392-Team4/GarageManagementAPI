using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductCategory : BaseEntity<ProductCategory>
    {
        public string Category { get; set; } = null!;

        [EnumDataType(typeof(ProductCategoryStatus))]
        public ProductCategoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}

