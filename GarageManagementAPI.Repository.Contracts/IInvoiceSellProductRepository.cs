using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IInvoiceSellProductRepository
    {
        Task CreateInvoiceSellProductAsync(InvoiceSellProduct invoiceSellProduct);
    }
}
