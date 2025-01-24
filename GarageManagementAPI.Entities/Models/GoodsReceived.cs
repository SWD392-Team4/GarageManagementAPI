namespace GarageManagementAPI.Entities.Models
{
    public class GoodsReceived : BaseEntity<GoodsReceived>
    {
        public Guid CreatedBy { get; set; }

        public Guid SupplierId { get; set; }

        public Guid WarehouseId { get; set; }

        public required string ReferenceNumber { get; set; }

        public required string InvoiceCode { get; set; }

        public User? Employee { get; set; }

        public Supplier? Supplier { get; set; }

        public Warehouse? Warehouse { get; set; }

        public ICollection<GoodsIssuedDetail>? GoodsIssuedDetails { get; set; }
    }
}