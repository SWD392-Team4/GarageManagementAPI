using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductCategory
{
    public record ProductCategoryDtoForUpdate : ProductCategoryDtoForManipulation
    {
        [EnumDataType(typeof(ProductCategoryStatus))]
        public ProductCategoryStatus Status { get; set; }
    }
}
