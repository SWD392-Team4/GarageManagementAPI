using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDto : BaseDto<GoodsIssuedDetailDto>
    {
        public Guid Id { get; set; }
        public string ProductAtWareHouseId { get; set; } = null!;

        public string ProductAtGarageID { get; set; } = null!;

        public string ReferenceNumberGoodIssued { get; set; } = null!;

        public int Quantity { get; set; }

        [EnumDataType(typeof(GoodsIssuedDetailStatus))]
        public GoodsIssuedDetailStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
