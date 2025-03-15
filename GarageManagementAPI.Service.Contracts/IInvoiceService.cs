using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IInvoiceService
    {
        Task<Result<InvoiceDto>> CreateInvoice(InvoiceDtoForCreation invoiceDtoForCreation, Guid userId);
    }
}
