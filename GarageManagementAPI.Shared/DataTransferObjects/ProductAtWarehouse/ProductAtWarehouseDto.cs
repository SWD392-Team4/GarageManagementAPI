using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse
{
    public record class ProductAtWarehouseDto : BaseDto<ProductAtWarehouseDto>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public Guid GoodsReceivedDetailId { get; set; }
    }
}
