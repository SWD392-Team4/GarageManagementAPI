using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductAtGarageParameters : RequestParameters
    {
        public ProductAtGarageParameters() => OrderBy = "CreatedAt";
        public int? minQuantity { get; set; } = 0;
        public int maxQuantity { get; set; }
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus? ProductStatus { get; set; } = null;
    }
}
