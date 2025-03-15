using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;


namespace GarageManagementAPI.Repository
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            await base.CreateAsync(invoice);
        }
    }
}
