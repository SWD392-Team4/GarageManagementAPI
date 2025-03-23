using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;

namespace GarageManagementAPI.Shared.DataTransferObjects.ReplacementPart
{
    public record ReplacementPartDto
    {
        public Guid InvoiceDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public Guid ProductAtGarageId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ProductDto? Product { get; set; }

        public ProductHistoryDto? ProductHistory { get; set; }

    }

}
