using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductAtWarehouseParameters : RequestParameters
    {
        public ProductAtWarehouseParameters() => OrderBy = "CreatedAt";
        public int minQuantity { get; set; } = 0;
        public int? maxQuantity { get; set; } = null!; 

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
