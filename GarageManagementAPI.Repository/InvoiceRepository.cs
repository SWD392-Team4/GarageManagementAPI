using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;


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

        public async Task<Invoice?> GetInvoice(Guid invoiceId, bool trackChanges, string? include = default)
        {
            var invoice = include == null
                          ?
                          await FindByCondition(i => i.Id.Equals(invoiceId), trackChanges).SingleOrDefaultAsync()
                          :
                          await FindByCondition(i => i.Id.Equals(invoiceId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return invoice;
        }

        public async Task<PagedList<Invoice>> GetInvoices(Guid? garageId, InvoiceParameters invoiceParameters, bool trackChanges, string? include)
        {
            var invoices = garageId == null ?
                await FindByCondition(i => i.GarageId.Equals(garageId), trackChanges)
                            .IsInclude(include)
                            .Sort(invoiceParameters.OrderBy)
                            .ToListAsync()  
                :
                await FindAll(trackChanges)
                          .IsInclude(include)
                          .Sort(invoiceParameters.OrderBy)
                          .ToListAsync();

            return PagedList<Invoice>.ToPagedList(
                invoices,
                invoiceParameters.PageNumber,
                invoiceParameters.PageSize
                );
        }

        public async Task<PagedList<Invoice>> GetInvoices(string phone, InvoiceParameters invoiceParameters, bool trackChanges, string? include)
        {
            var invoices =
              await FindByCondition(i => i.CustomerPhoneNumber.Equals(phone), trackChanges)
                        .IsInclude(include)
                        .Sort(invoiceParameters.OrderBy)
                        .ToListAsync();

            return PagedList<Invoice>.ToPagedList(
                invoices,
                invoiceParameters.PageNumber,
                invoiceParameters.PageSize
                );
        }
    }
}
