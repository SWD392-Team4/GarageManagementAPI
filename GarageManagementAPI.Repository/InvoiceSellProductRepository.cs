using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class InvoiceSellProductRepository : RepositoryBase<InvoiceSellProduct>, IInvoiceSellProductRepository
    {
        public InvoiceSellProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateInvoiceSellProductAsync(InvoiceSellProduct invoiceSellProduct)
        {
            await CreateAsync(invoiceSellProduct);
        }
    }
}
