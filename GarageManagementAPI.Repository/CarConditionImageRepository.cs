using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Repository
{
    public class CarConditionImageRepository : RepositoryBase<CarConditionImage>, ICarConditionImageRepository
    {
        public CarConditionImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<CarConditionImage?> GetCarConditionImageAsync(Guid appointmentDetailId, Guid id, bool trackChanges)
        {
            return await FindByCondition(p => p.Id.Equals(id) && p.AppointmentDetailId.Equals(appointmentDetailId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<CarConditionImage>> GetCarConditionImagesAsync(Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters, bool trackChanges)
        {
            var carConditionImages = await FindByCondition(p => p.AppointmentDetail.AppointmentId.Equals(appointmentId) && p.AppointmentDetailId.Equals(appointmentDetailId), trackChanges)
                .FilterByStage(carConditionImageParameters.Stage)
                .Sort(carConditionImageParameters.OrderBy)
                .Skip((carConditionImageParameters.PageNumber - 1) * carConditionImageParameters.PageSize)
                .Take(carConditionImageParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(p => p.AppointmentDetail.AppointmentId.Equals(appointmentId) && p.AppointmentDetailId.Equals(appointmentDetailId), trackChanges)
                .FilterByStage(carConditionImageParameters.Stage)
                .CountAsync();

            return new PagedList<CarConditionImage>(
                carConditionImages,
                count,
                carConditionImageParameters.PageNumber,
                carConditionImageParameters.PageSize);
        }
    }
}
