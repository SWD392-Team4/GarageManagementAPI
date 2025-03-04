

using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDtoForUpdate : GoodsReceivedDtoForManipulation
    {
        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus Status { get; set; } = GoodsReceivedStatus.Inactive;
    }
}
