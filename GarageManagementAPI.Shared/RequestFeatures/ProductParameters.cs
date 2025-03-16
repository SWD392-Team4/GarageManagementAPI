using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{

    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "ProductName";
        public string? ProductName { get; set; }
        public string? ProductCategory{ get; set; }
        public string? ProductBrandName { get; set; }
        public string? ProductBarcode { get; set; }
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus? ProductStatus { get; set; } = null;
    }
}
