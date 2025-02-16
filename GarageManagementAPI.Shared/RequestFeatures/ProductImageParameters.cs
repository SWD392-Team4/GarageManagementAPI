using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductImageParameters : RequestParameters
    {
        public ProductImageParameters() => OrderBy = "status";
        [EnumDataType(typeof(ProductImageStatus))]
        public ProductImageStatus? Status { get; set; } = null;
    }
}
