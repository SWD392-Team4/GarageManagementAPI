using GarageManagementAPI.Shared.DataTransferObjects.InvoicePackageDetail;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceServiceDetail;
using GarageManagementAPI.Shared.Enums;

using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Invoice
{
    public record class InvoiceDto : BaseDto<InvoiceDto>
    {
        public Guid Id { get; set; }
        [EnumDataType(typeof(InvoiceType))]
        public InvoiceType InvoiceType { get; set; }

        public Guid? CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual ICollection<InvoiceSellProductDto> InvoiceSellProducts { get; set; } = new List<InvoiceSellProductDto>();

        public virtual ICollection<InvoicePackageDetailDto> InvoicePackageDetails { get; set; } = new List<InvoicePackageDetailDto>();

        public virtual ICollection<InvoiceServiceDetailDto> InvoiceServiceDetails { get; set; } = new List<InvoiceServiceDetailDto>();
    }
}
