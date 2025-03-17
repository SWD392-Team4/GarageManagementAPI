using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Invoice
{
    public static class InvoiceErrors
    {
        #region const
        public const string InvoiceNotFound = "Invoice not found with id {0}";
        #endregion
        #region errors
        public static ErrorsResult GetInvoiceNotFoundErrors(Guid invoiceId) 
            => new ErrorsResult { Code = InvoiceNotFound, Description= string.Format(InvoiceNotFound, invoiceId) };
        #endregion
    }
}
