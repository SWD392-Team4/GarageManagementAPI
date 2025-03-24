using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IInvoiceRepository
    {
        Task CreateInvoiceAsync(Invoice invoice);

        Task<Invoice?> GetInvoice(Guid invoiceId, bool trackChanges, string? include = default);

        Task<PagedList<Invoice>> GetInvoices(Guid? garageId, InvoiceParameters invoiceParameters, bool trackChanges, string? include);

        Task<PagedList<Invoice>> GetInvoices(string phone, InvoiceParameters invoiceParameters, bool trackChanges, string? include);

        Task<PagedList<Invoice>> GetInvoices(string email, string phone, InvoiceParameters invoiceParameters, bool trackChanges, string? include);

        Task<IEnumerable<RevenueByMonthDto>> GetMonthlyRevenueByYear(Guid? garageId, int year, bool trackChanges);

    }
}
