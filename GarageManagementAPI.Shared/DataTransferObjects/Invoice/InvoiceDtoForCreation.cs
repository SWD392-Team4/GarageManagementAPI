using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;

namespace GarageManagementAPI.Shared.DataTransferObjects.Invoice
{
    public record InvoiceDtoForCreation
    {
        public string? CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; } = null!;

        public string? CustomerEmail { get; set; }

        public virtual List<InvoiceSellProductDtoForCreation>? InvoiceSellProducts { get; set; }
    }
}
