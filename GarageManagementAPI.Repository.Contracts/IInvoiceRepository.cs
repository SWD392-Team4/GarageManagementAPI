using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IInvoiceRepository
    {
        Task CreateInvoiceAsync(Invoice invoice);
    }
}
