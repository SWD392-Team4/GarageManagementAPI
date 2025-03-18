using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarConditionImageRepository : IRepositoryBase<CarConditionImage>
    {
        Task<PagedList<CarConditionImage>> GetCarConditionImagesAsync(Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters, bool trackChanges);

        Task<CarConditionImage?> GetCarConditionImageAsync(Guid appointmentDetailId, Guid id, bool trackChanges);
    }
}
