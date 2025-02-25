using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceImageRepository : IRepositoryBase<ServiceImage>
    {
        Task<PagedList<ServiceImage>> GetServiceImgByIdAsync(Guid serviceImageId, ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = default);
        Task<ServiceImage?> GetServiceImgByStatusAndIdSerciceAsync(Guid serviceImageId, bool trackChanges, string? include = default);
        Task<ServiceImage?> GetServiceImgByLinkAndIdSerciceAsync(Guid serviceImageId, bool trackChanges, string? include = default);
        Task<PagedList<ServiceImage>> GetServiceImgesAsync(ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = default);
        Task CreateServiceImgAsync(ServiceImage serviceImage);
        void UpdateServiceProductImg(ServiceImage serviceImage);
    }
}
