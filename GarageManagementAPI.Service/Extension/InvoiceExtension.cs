using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.Invoice;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;


namespace GarageManagementAPI.Invoice.Extension
{
    public static class InvoiceExtension
    {
        public static Result<Entities.Models.Invoice> OkResult(this Entities.Models.Invoice Invoice)
     => Result<Entities.Models.Invoice>.Ok(Invoice);

        public static Result<InvoiceDto> OkResult(this InvoiceDto InvoiceDto)
            => Result<InvoiceDto>.Ok(InvoiceDto);

        public static Result<InvoiceDto> CreatedResult(this InvoiceDto InvoiceDto)
            => Result<InvoiceDto>.Created(InvoiceDto);

        public static Result<Entities.Models.Invoice> NotFound(this Entities.Models.Invoice? Invoice, Guid InvoiceId)
            => Result<Entities.Models.Invoice>.NotFound([InvoiceErrors.GetInvoiceNotFoundErrors(InvoiceId)]);
    }
}
