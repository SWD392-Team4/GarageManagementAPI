namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDtoForManipulation
    {
        public Guid ProductAtWareHouseId { get; set; }
        public Guid GoodsIssuedId { get; set; }
        public int Quantity { get; set; }
    }
}
