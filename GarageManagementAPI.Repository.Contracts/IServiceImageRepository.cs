using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceImageRepository : IRepositoryBase<ServiceImage>
    {
        Task<PagedList<ServiceImage>> GetServiceImgByIdServiceAsync(Guid serviceId, ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = default);
        Task<ServiceImage?> GetServiceImgageAsync(Guid serviceImageId, bool trackChanges, string? include = default);
        Task CreateServiceImgAsync(ServiceImage serviceImage);
        void UpdateServiceImage(ServiceImage serviceImage);
    }
}
