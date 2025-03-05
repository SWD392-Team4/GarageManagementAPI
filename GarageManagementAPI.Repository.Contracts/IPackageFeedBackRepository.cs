using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageFeedBackRepository : IRepositoryBase<PackageFeedBack>
    {
        Task<PackageFeedBack?> GetPackageFeedBackByIdAsync(Guid id, bool trackChanges);
        Task<PagedList<PackageFeedBack>> GetPackageFeedBacksAsync(PackageFeedBackParameters packageFeedBackParameters, bool trackChanges);
    }
}
