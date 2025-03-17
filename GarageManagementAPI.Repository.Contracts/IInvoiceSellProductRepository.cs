using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IInvoiceSellProductRepository
    {
        Task CreateInvoiceSellProductAsync(InvoiceSellProduct invoiceSellProduct);

        Task<InvoiceSellProduct?> GetInvoiceSellProduct(Guid invoiceSellProductId, bool trackChanges, string? include = default);

        Task<IEnumerable<InvoiceSellProduct>> GetInvoiceSellProducts(Guid invoiceId, InvoiceSellProductParameters invoiceSellProductParameters, bool trackChanges, string? include = default);
    }
}
