using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceHistoryService
    {
        public Task<Result<IEnumerable<ExpandoObject>>> GetServiceHistoryByServiceIdAsync(Guid ServiceId, ServiceHistoryParameters serviceHistoryParameters, bool trackChanges, string? include = null);
    }
}
