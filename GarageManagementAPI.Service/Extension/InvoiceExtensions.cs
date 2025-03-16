using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class InvoiceExtensions
    {
        public static Result<Invoice> OkResult(this Invoice invoice)
            => Result<Invoice>.Ok(invoice);

        public static Result<InvoiceDto> OkResult(this InvoiceDto invoiceDto)
            => Result<InvoiceDto>.Ok(invoiceDto);

        public static Result<InvoiceDto> CreatedResult(this InvoiceDto invoiceDto)
            => Result<InvoiceDto>.Created(invoiceDto);
    }
}
