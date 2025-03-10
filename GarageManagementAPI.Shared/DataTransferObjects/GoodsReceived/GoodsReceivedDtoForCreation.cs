using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDtoForCreation : GoodsReceivedDtoForManipulation
    {
       public List<GoodsReceivedDetailDtoForCreationGoods> goodsIssuedDetailDtoForCreations { get; set; } = new List<GoodsReceivedDetailDtoForCreationGoods>();
    }
}
