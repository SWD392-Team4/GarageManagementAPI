using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse
{
    public record class ProductAtWarehouseDtoForUpdate
    {
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }
    }
}
