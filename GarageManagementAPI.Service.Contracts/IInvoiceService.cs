using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IInvoiceService
    {
        Task<Result<InvoiceDto>> CreateInvoice(InvoiceDtoForCreation invoiceDtoForCreation, Guid userId);

        Task<Result<InvoiceDto>> GetInvoice(Guid invoiceId, bool trackChanges, string? include = null);

        Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForAdmin(Guid? garageId, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null);

        Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForCahier(Guid userId, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null);


        Task<Result<IEnumerable<ExpandoObject>>> GetInvoicesForCustomers(string phoneNumber, InvoiceParameters invoiceParameters, bool trackChanges, string? include = null);


        Task<Result<InvoiceSellProductDto>> GetInvoiceSellProduct(Guid invoiceId, bool trackChanges, string? include = null);

        Task<Result<IEnumerable<ExpandoObject>>> GetInvoiceSellProducts(Guid invoiceId, InvoiceSellProductParameters invoiceSellProductParameters, bool trackChanges, string? include = null);

        Task<IEnumerable<RevenueByMonthDto>> GetMonthlyRevenueByYear(Guid? garageId, int year, bool trackChanges);

    }
}