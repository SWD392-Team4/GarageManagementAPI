using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductHistoryService
    {
        public Task<Result<IEnumerable<ExpandoObject>>> GetHistoryProductByIdProductAsync(Guid productId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductHistoriesAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null);
    }
}