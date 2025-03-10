namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail
{
    public record class GoodsReceivedDetailDtoForManipulation
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid ProductId { get; set; }
    }
}
