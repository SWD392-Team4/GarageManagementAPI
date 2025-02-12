using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductHistoryService
    {
        public Task<Result<IEnumerable<ExpandoObject>>> GetHistoryProductByIdProductAsync(Guid productHistoryId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductHistoriesAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null);
        public Task<Result<ProductHistoryDto>> CreateProductHistoryAsync(ProductHistoryDtoForCreation ProductHistoryDtoForCreation);
    }
}
