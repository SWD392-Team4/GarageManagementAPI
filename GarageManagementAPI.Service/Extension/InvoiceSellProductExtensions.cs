using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.InvoiceSellProduct;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;

namespace GarageManagementAPI.Service.Extension
{
    public static class InvoiceSellProductExtensions
    {
        public static Result<Entities.Models.InvoiceSellProduct> OkResult(this Entities.Models.InvoiceSellProduct invoice)
      => Result<Entities.Models.InvoiceSellProduct>.Ok(invoice);

        public static Result<InvoiceSellProductDto> OkResult(this InvoiceSellProductDto invoiceDto)
            => Result<InvoiceSellProductDto>.Ok(invoiceDto);

        public static Result<InvoiceSellProductDto> CreatedResult(this InvoiceSellProductDto invoiceDto)
            => Result<InvoiceSellProductDto>.Created(invoiceDto);

        public static Result<Entities.Models.InvoiceSellProduct> NotFound(this Entities.Models.InvoiceSellProduct? invoice, Guid invoiceId)
            => Result<Entities.Models.InvoiceSellProduct>.NotFound([InvoiceSellProductErrors.GetInvoiceSellProductNotFoundErrors(invoiceId)]);
    }
}
