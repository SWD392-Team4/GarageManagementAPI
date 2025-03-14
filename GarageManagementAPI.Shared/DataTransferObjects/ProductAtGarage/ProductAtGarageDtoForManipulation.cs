namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage
{
    public record class ProductAtGarageDtoForManipulation
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public int Quantity { get; set; }
        public string ProductBarcodeAtGarage { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }

    }
}
