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

        public void UpdateServiceImage(ServiceImage serviceImage)
        {
            base.Update(serviceImage);
        }

        public async Task<PagedList<ServiceImage>> GetServiceImgByIdServiceAsync(Guid serviceId, ServiceImageParameters serviceImageParameters, bool trackChanges, string? include = null)
        {
            var imgs = await FindByCondition(sm => sm.ServiceId == serviceId, trackChanges)
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

        public async Task<ServiceImage?> GetServiceImgageAsync(Guid serviceImageId, bool trackChanges, string? include = null)
        {
            Console.WriteLine(serviceImageId);
            var serviceImage = await FindByCondition(s => s.Id == serviceImageId, trackChanges).SingleOrDefaultAsync();
            Console.WriteLine("After: " + serviceImage?.Id);
            return serviceImage;
        }
    }
}
