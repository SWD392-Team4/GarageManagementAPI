namespace GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct
{
    public record class InvoiceSellProductDtoForCreation
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
