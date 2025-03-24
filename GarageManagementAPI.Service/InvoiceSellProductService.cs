using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Service
{
    public class InvoiceSellProductService : IInvoiceSellProductService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public InvoiceSellProductService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<IEnumerable<ProductSellStatisticsDto>> GetSales(int year, Guid? garageId, bool trackChanges)
        {
            var sales = await _repoManager.InvoiceSellProduct.GetSales(year, garageId, trackChanges);
            return sales;
        }
    }
}
