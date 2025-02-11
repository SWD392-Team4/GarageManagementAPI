using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{

    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "name";
        public string? ProductName { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public ProductStatus Status { get; set; }
    }
}
