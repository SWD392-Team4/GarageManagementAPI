namespace GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage
{
    public record class ProductAtGarageDto : BaseDto<ProductAtGarageDto>
    {
        public Guid Id {  get; set; } 
        public Guid GoodsIssuedDetailId { get; set; }
        public int Quantity { get; set; }
        public string ProductBarcodeAtGarage { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }

    }
}
