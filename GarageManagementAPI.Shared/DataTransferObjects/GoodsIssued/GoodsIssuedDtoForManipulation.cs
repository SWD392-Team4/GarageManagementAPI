namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDtoForManipulation
    {
        public string ReferenceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;
        public Guid WarehouseId { get; set; }
        public Guid GarageId { get; set; }

    }
}
