using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.InvoiceSellProduct
{
    public static class InvoiceSellProductErrors
    {
        public const string Quantity = "Some products do not have enough stock.";
        public static ErrorsResult GetQuantityIsOutOfRange()
        => new() { Code = Quantity, Description = Quantity };
    }
}
