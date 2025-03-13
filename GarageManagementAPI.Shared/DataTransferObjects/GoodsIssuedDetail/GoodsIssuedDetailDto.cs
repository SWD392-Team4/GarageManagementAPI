using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDto : BaseDto<GoodsIssuedDetailDto>
    {
        public Guid ProductAtWareHouseId { get; set; }
        public Guid GoodsIssuedId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
