using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductCategoryParameters : RequestParameters
    {
        public ProductCategoryParameters() => OrderBy = "category";
        public string? Category { get; set; } = null!;

        [EnumDataType(typeof(ProductCategoryStatus))]
        public ProductCategoryStatus? Status { get; set; } = null;

    }
}
