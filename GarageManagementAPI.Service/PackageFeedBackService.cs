using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack;

namespace GarageManagementAPI.Service
{
    public class PackageFeedBackService : IPackageFeedBackService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageFeedBackService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<PackageFeedBackDto>> CreatePackageFeedBackAsync(PackageFeedBackDtoForCreation packageFeedBackDtoForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PackageFeedBackDto>> GetPackageFeedBackByIdAsync(Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<PackageFeedBackDto>>> GetPackageFeedBacksAsync(PackageFeedBackParameters packageFeedBackParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemovePackageFeedBackAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdatePackageFeedBackAsync(Guid id, PackageFeedBackDtoForUpdate packageFeedBackDtoForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
