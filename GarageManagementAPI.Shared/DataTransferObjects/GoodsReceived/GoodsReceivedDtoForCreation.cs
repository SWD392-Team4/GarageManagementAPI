using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDtoForCreation : GoodsReceivedDtoForManipulation
    {
       public List<GoodsReceivedDetailDtoForCreationGoods> goodsReceivedDetailDtoForCreations { get; set; } = new List<GoodsReceivedDetailDtoForCreationGoods>();
    }
}
