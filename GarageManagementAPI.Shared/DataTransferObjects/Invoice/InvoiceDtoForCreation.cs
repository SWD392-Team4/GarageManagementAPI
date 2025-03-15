using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Invoice
{
    public record InvoiceDtoForCreation
    {
        [EnumDataType(typeof(InvoiceType))]
        public InvoiceType InvoiceType { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public virtual ICollection<InvoiceSellProductDtoForCreation> InvoiceSellProducts { get; set; } = new List<InvoiceSellProductDtoForCreation>();
    }
}
