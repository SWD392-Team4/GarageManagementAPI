using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail
{
    public record class GoodsReceivedDetailDto : BaseDto<GoodsReceivedDetailDto>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedDetailStatus))]
        public GoodsReceivedDetailStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
        public Guid ProductId { get; set; }
    }
}
