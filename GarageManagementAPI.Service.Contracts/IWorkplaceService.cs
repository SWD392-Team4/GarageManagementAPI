using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IWorkplaceService
    {
        public Task<Result<ExpandoObject>> GetWorkplace(Guid workplaceId, WorkplaceParameters workplaceParameters, bool trackChanges);

        public Task<Result<IEnumerable<ExpandoObject>>> GetWorkplaces(WorkplaceParameters workplaceParameters, bool trackChanges);

        public Task<Result<WorkplaceDtoForUpdate>> GetWorkplaceForPartiallyUpdate(Guid workplaceId, bool trackChanges);

        public Task<Result<WorkplaceDto>> CreateWorkplace(WorkplaceDtoForCreation workplaceDtoForCreation);

        public Task<Result> UpdateWorkplace(Guid workplaceId, WorkplaceDtoForUpdate workplaceDtoForUpdate, bool trackChanges);

    }
}
