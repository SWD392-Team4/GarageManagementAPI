using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Extension;

namespace GarageManagementAPI.Repository
{
    public class ServiceHistoryRepository : RepositoryBase<ServiceHistory>, IServiceHistoryRepository
    {
        public ServiceHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async new Task CreateAsync(ServiceHistory entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(entity);
        }

        public async Task<PagedList<ServiceHistory>> GetServiceHistoryByIdSerivceAsync(Guid serviceId, ServiceHistoryParameters ServiceHistoryParameters, bool trackChanges, string? include = null)
        {
            var servicesQuery = FindByCondition(s =>
                  s.ServiceId.Equals(serviceId), trackChanges)
                 .SearchByPrice(ServiceHistoryParameters.Price)
                 .Sort(ServiceHistoryParameters.OrderBy)
                 .IsInclude(include)
                 .AsQueryable();

            var serviceHistories = await servicesQuery
            .Skip((ServiceHistoryParameters.PageNumber - 1) * ServiceHistoryParameters.PageSize)
            .Take(ServiceHistoryParameters.PageSize)
            .ToListAsync();

            var count = await servicesQuery.CountAsync();

            return new PagedList<ServiceHistory>(
                serviceHistories,
                count,
                ServiceHistoryParameters.PageNumber,
                ServiceHistoryParameters.PageSize
            );
        }

        public async Task<PagedList<ServiceHistory>> GetServiceHistoryAsync(ServiceHistoryParameters ServiceHistoryParameters, bool trackChanges, string? include = null)
        {
            var services = await FindAll(trackChanges)
                .SearchByPrice(ServiceHistoryParameters.Price)
                .Sort(ServiceHistoryParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();

            return PagedList<ServiceHistory>.ToPagedList(
                services,
                ServiceHistoryParameters.PageNumber,
                ServiceHistoryParameters.PageSize
            );
        }

        public async Task<IEnumerable<ServiceHistory>> GetServiceHistoriesAsync(IEnumerable<Guid> serviceIds, bool trackChanges)
        {
            var serviceHistories = await FindByCondition(s => serviceIds.Contains(s.ServiceId), trackChanges)
                  .GroupBy(s => s.ServiceId)
                  .Select(g => g.OrderByDescending(s => s.CreatedAt).First())
                  .ToListAsync();

            return serviceHistories;
        }

        public async Task<ServiceHistory?> GetServiceHistory(Guid serviceId, bool trackChanges, string? include = null)
        {
            var serviceHistory = await FindByCondition(s => s.ServiceId.Equals(serviceId), trackChanges)
                .OrderByDescending(s => s.CreatedAt)
                .IsInclude(include)
                .FirstOrDefaultAsync();
            return serviceHistory;
        }
    }
}
