namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse
{
    public record class ProductAtWarehouseDtoForManipulation
    {
        public Guid GoodsReceivedDetailId { get; set; }

        public int Quantity { get; set; }
    }
}
