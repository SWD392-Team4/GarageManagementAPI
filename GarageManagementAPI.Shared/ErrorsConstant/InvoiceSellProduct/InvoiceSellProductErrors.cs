using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.InvoiceSellProduct
{
    public static class InvoiceSellProductErrors
    {
        public const string Quantity = "Some products do not have enough stock.";
        public const string InvoiceSellProduct = "Invoice sell product doesn't with id {0}";
        public static ErrorsResult GetQuantityIsOutOfRange()
        => new() { Code = Quantity, Description = Quantity };
        public static ErrorsResult GetInvoiceSellProductNotFoundErrors(Guid invoicesellProductId)
        => new() { Code = InvoiceSellProduct, Description = string.Format(InvoiceSellProduct, invoicesellProductId) };
    }
}
