using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository
{
    public class ServiceHistoryRepository : RepositoryBase<ServiceHistory>, IServiceHistoryRepository
    {
        public ServiceHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateProductHisotoryAsync(ServiceHistory productHisotry)
        {
            await base.CreateAsync(productHisotry);
        }

        public void UpdateServiceHistory(ServiceHistory ServiceHistory)
        {
            base.Update(ServiceHistory);
        }

        public async Task<PagedList<ServiceHistory>> GetServiceHistoryByIdSerivceAsync(Guid serviceId, ServiceHistoryParameters ServiceHistoryParameters, bool trackChanges, string? include = null)
        {
            var servicesQuery = FindByCondition(s =>
                  s.ServiceId.Equals(serviceId), trackChanges)
                 .SearchByPrice(ServiceHistoryParameters.Price)
                 .SearchByStatus(ServiceHistoryParameters.Status)
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
                .SearchByStatus(ServiceHistoryParameters.Status)
                .Sort(ServiceHistoryParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();

            return PagedList<ServiceHistory>.ToPagedList(
                services,
                ServiceHistoryParameters.PageNumber,
                ServiceHistoryParameters.PageSize
            );
        }

        public Task<ServiceHistory?> GetServiceHistoryByPriceAndIdServiceAsync(Guid serviceId, decimal price, bool trackChanges, string? include = null)
        {
            var ServiceHistory = FindByCondition(p => p.ServiceId.Equals(serviceId) && p.Price == price, false)
                   .OrderByDescending(p => p.UpdatedAt)
                   .FirstOrDefaultAsync();
            return ServiceHistory;
        }

        public Task<ServiceHistory?> GetServiceHistoryByStatusAndIdServiceAsync(Guid serviceId, bool trackChanges, string? include = null)
        {
            var ServiceHistory = FindByCondition(s => s.Status == ServiceHistoryStatus.Active && s.ServiceId == serviceId, false).OrderByDescending(p => p.UpdatedAt)
                                   .FirstOrDefaultAsync();
            return ServiceHistory;
        }
    }
}
