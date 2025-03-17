using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

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

        public async Task<InvoiceSellProduct?> GetInvoiceSellProduct(Guid invoiceSellProductId, bool trackChanges, string? include = default)
        {
            var invoiceSellProduct =
                include == null ?
                await FindByCondition(i => i.Id.Equals(invoiceSellProductId), trackChanges).SingleOrDefaultAsync()
                :
                await FindByCondition(i => i.Id.Equals(invoiceSellProductId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return invoiceSellProduct;
        }

        public async Task<IEnumerable<InvoiceSellProduct>> GetInvoiceSellProducts(Guid invoiceId, InvoiceSellProductParameters invoiceSellProductParameters, bool trackChanges, string? include = default)
        {
            var invoiceSelllProducts = await FindByCondition(isp => isp.InvoiceId.Equals(invoiceId), trackChanges)
               // .SearchByQuantity(invoiceSellProductParameters.minQuantity, invoiceSellProductParameters.maxQuantity)
                .Include("Product")
                .Sort(invoiceSellProductParameters.OrderBy)
                .ToListAsync();

            return invoiceSelllProducts;
        }
    }
}
