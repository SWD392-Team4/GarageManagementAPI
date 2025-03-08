namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDtoForManipulation
    {
        public decimal TotalCost { get; set; }
        public string ReferenceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;
        public Guid CreatedWareHouseManagerId { get; set; }
        public Guid WarehouseId { get; set; }
    }
}
