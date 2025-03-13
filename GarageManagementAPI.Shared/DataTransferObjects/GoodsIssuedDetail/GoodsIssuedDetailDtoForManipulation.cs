namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDtoForManipulation
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
