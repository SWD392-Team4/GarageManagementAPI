using GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageFeedBackService
    {
        Task<Result<IEnumerable<PackageFeedBackDto>>> GetPackageFeedBacksAsync(PackageFeedBackParameters packageFeedBackParameters, bool trackChanges);
        Task<Result<PackageFeedBackDto>> GetPackageFeedBackByIdAsync(Guid id, bool trackChanges);
        Task<Result<PackageFeedBackDto>> CreatePackageFeedBackAsync(PackageFeedBackDtoForCreation packageFeedBackDtoForCreation);
        Task<Result> UpdatePackageFeedBackAsync(Guid id, PackageFeedBackDtoForUpdate packageFeedBackDtoForUpdate);
        Task<Result> RemovePackageFeedBackAsync(Guid id);
    }
}