using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.PackageUsageDetail;

namespace GarageManagementAPI.Service
{
    public class PackageUsageDetailService : IPackageUsageDetailService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageUsageDetailService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<PackageUsageDetailDto>> CreatePackageUsageDetailAsync(PackageUsageDetailDtoForCreation packageUsageDetailDtoForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PackageUsageDetailDto>> GetPackageUsageDetailByIdAsync(Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<PackageUsageDetailDto>>> GetPackageUsageDetailsAsync(PackageUsageDetailParameters packageUsageDetailParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemovePackageUsageDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdatePackageUsageDetailAsync(Guid id, PackageUsageDetailDtoForUpdate packageUsageDetailDtoForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
