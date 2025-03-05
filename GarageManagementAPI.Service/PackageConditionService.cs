using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;

namespace GarageManagementAPI.Service
{
    public class PackageConditionService : IPackageConditionService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageConditionService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<PackageConditionDto>> CreatePackageConditionAsync(Guid packageId, PackageConditionDtoForCreation packageConditionDtoForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PackageConditionDto>> GetPackageConditionByIdAsync(Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<PackageConditionDto>>> GetPackageConditionsAsync(PackageConditionParameters packageConditionParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemovePackageConditionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdatePackageConditionAsync(Guid id, PackageConditionDtoForUpdate packageConditionDtoForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
