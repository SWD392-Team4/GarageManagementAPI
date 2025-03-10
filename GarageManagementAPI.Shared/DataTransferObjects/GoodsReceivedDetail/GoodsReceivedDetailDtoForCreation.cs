namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail
{
    public record class GoodsReceivedDetailDtoForCreation : GoodsReceivedDetailDtoForManipulation
    {
        public Guid GoodsReceivedId { get; set; }
    }
}
