namespace GarageManagementAPI.Entities.Models
{
    public class GoodsIssued : BaseEntity<GoodsIssued>
    {
        public Guid CreateBy { get; set; }

        public Guid GarageId { get; set; }

        public Guid WarehouseId { get; set; }

        public required string ReferenceNumber { get; set; }

        public required string InvoiceCode { get; set; }

        public DateOnly ExportDate { get; set; }

        public User? Employee { get; set; }

        public Garage? Garage { get; set; }

        public Warehouse? Warehouse { get; set; }

        public ICollection<GoodsIssuedDetail>? GoodsIssuedDetails { get; set; }
    }
}