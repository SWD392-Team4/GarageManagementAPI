using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductCategory
{
    public record ProductCategoryDtoForManipulation
    {
        public string Category { get; set; } = null!;

    }
}
