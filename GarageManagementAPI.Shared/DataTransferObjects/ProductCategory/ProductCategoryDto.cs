using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductCategory
{
    // thay đổi giá trị của một đối tượng record by 'with'
    public record ProductCategoryDto : BaseDto<ProductCategoryDto>
    {
        public Guid Id { get; set; }
        public string Category { get; set; } = null!;

        [EnumDataType(typeof(ProductCategoryStatus))]
        public ProductCategoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
