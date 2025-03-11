namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDtoForCreation : GoodsIssuedDetailDtoForManipulation
    {
        public Guid GoodsReceivedId { get; set; }
    }
}
