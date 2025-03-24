using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IInvoiceSellProductService
    {
      Task<IEnumerable<ProductSellStatisticsDto>> GetSales(int year, Guid? garageId, bool trackChanges);
    }
}
