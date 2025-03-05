using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.PackageUsage;

namespace GarageManagementAPI.Service
{
    public class PackageUsageService : IPackageUsageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageUsageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<PackageUsageDto>> CreatePackageUsageAsync(PackageUsageDtoForCreation packageUsageDtoForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PackageUsageDto>> GetPackageUsageByIdAsync(Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<PackageUsageDto>>> GetPackageUsagesAsync(PackageUsageParameters packageUsageParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemovePackageUsageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdatePackageUsageAsync(Guid id, PackageUsageDtoForUpdate packageUsageDtoForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
