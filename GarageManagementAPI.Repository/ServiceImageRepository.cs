using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    internal class ServiceImageRepository : RepositoryBase<ServiceImage>, IServiceImageRepository
    {
        public ServiceImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateServiceImgAsync(ServiceImage serviceImage)
        {
            await base.CreateAsync(serviceImage);
        }

        public void UpdateServiceProductImg(ServiceImage serviceImage)
        {
            base.Update(serviceImage);
        }

        public async Task<PagedList<ServiceImage>> GetServiceImgByIdAsync(Guid serviceImageId, ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = null)
        {
            var imgs = await FindByCondition(sm => sm.ServiceId.Equals(serviceImageId), trackChanges)
                           .SearchByStatus(serviceImageParameters.Status)
                           .Sort(serviceImageParameters.OrderBy)
                           .IsInclude(include)
                           .ToListAsync();

            return PagedList<ServiceImage>.ToPagedList(
               imgs,
               serviceImageParameters.PageNumber,
               serviceImageParameters.PageSize
           );
        }

        public Task<ServiceImage?> GetServiceImgByLinkAndIdSerciceAsync(Guid serviceImageId, bool trackChanges, string? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceImage?> GetServiceImgByStatusAndIdSerciceAsync(Guid serviceImageId, bool trackChanges, string? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<ServiceImage>> GetServiceImgesAsync(ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = null)
        {
            throw new NotImplementedException();
        }
    }
}
