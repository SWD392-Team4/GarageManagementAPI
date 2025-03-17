using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Invoice
{
    public record class InvoiceDto : BaseDto<InvoiceDto>
    {
        public Guid Id { get; set; }
        [EnumDataType(typeof(InvoiceType))]
        public InvoiceType InvoiceType { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
