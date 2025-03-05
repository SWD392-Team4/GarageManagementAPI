using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail
{
    public record class GoodsReceivedDetailDtoForUpdate : GoodsReceivedDetailDtoForManipulation
    {
        [EnumDataType(typeof(GoodsReceivedDetailStatus))]
        public GoodsReceivedDetailStatus? Status { get; set; } = GoodsReceivedDetailStatus.Inactive;
    }
}
