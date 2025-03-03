using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductImage : BaseEntity<ProductImage>
    {
        public Guid ProductId { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        [EnumDataType(typeof(ProductImageStatus))]
        public ProductImageStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual Product Product { get; set; } = null!;
    }

}

