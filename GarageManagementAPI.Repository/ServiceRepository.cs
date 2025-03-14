using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Repository.Extensions;

namespace GarageManagementAPI.Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async new Task CreateAsync(Service entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(entity);
        }
        public new void Update(Service entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            base.Update(entity);
        }

        public async Task<IEnumerable<Service>> GetServiceByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
            => await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

        public async Task<Service?> GetServiceByIdAsync(Guid serviceId, bool trackChanges, string? include = null)
        {
            var service = include is null ?
            await FindByCondition(u => u.Id.Equals(serviceId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(u => u.Id.Equals(serviceId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return service;
        }

        public async Task<Service?> GetServiceByIdAndNameAsync(string name, Guid? serviceId, bool trackChanges)
        {
            var service = serviceId is null ?
            await FindByCondition(s => s.ServiceName.Equals(name), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(s => !s.Id.Equals(serviceId) && s.ServiceName.ToLower().Equals(name.ToLower()), trackChanges).SingleOrDefaultAsync();

            return service;
        }

        public async Task<PagedList<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            var services = await FindAll(trackChanges)
                .SearchByName(serviceParameters.ServiceName)
                .SearchByCreateAt(serviceParameters.CreatedAt) 
                .SearchByUpdateAt(serviceParameters.UpdatedAt) 
                .SearchByWorkNature(serviceParameters.WorkNature)
                .SearchByServiceCategory(serviceParameters.ServiceCategory)
                .SearchByAction(serviceParameters.Action)
                .SearchByStatus(serviceParameters.Status)
                .Sort(serviceParameters.OrderBy)
                .IsInclude(include)
                .SearchByCarCategory(serviceParameters.CarCategoryName)
                .SearchByCarPart(serviceParameters.CarPartName)
                .ToListAsync();



            return PagedList<Service>.ToPagedList(
                services,
                serviceParameters.PageNumber,
                serviceParameters.PageSize
            );
        }

        public async Task<Service?> GetServiceByCarCategoryAnCarPartId(Guid? serviceId, Guid carPartId, Guid carparCategoryId, WorkNature workNature, ServiceAction action, bool trackChanges, string? include = null)
        {
            var service =
                await FindByCondition(s => s.CarCategoryId.Equals(carparCategoryId) && s.CarPartId.Equals(carPartId) && s.WorkNature.Equals(workNature) && s.Action.Equals(action) && !s.Id.Equals(serviceId), trackChanges).SingleOrDefaultAsync();
            return service;
        }

        public async Task<IEnumerable<Service>> GetServiceByPackageHistoryIdAsync(Guid pacakgeHistoryId, bool trackChanges)
        {
            return await FindByCondition(x => x.PackageHistories.Any(x => x.Id.Equals(pacakgeHistoryId)), trackChanges).ToListAsync();
        }

        public async Task<PagedList<Service>> GetServiceByPackageHistoryIdAsync(Guid pacakgeHistoryId, bool trackChanges, ServiceParameters serviceParameters, string? include = default)
        {
            var services = await FindByCondition(s => s.PackageHistories.Any(p => p.Id.Equals(pacakgeHistoryId)), trackChanges)
                    .SearchByName(serviceParameters.ServiceName)
                    .SearchByCreateAt(serviceParameters.CreatedAt)
                    .SearchByUpdateAt(serviceParameters.UpdatedAt)
                    .SearchByWorkNature(serviceParameters.WorkNature)
                    .SearchByServiceCategory(serviceParameters.ServiceCategory)
                    .SearchByAction(serviceParameters.Action)
                    .SearchByStatus(serviceParameters.Status)
                    .SearchByCarCategory(serviceParameters.CarCategoryName)
                    .SearchByCarPart(serviceParameters.CarPartName)
                    .Sort(serviceParameters.OrderBy)
                    .Skip((serviceParameters.PageNumber - 1) * serviceParameters.PageSize)
                    .Take(serviceParameters.PageSize)
                    .IsInclude(include)
                    .ToListAsync();

            var count = await FindByCondition(s => s.PackageHistories.Any(p => p.Id.Equals(pacakgeHistoryId)), trackChanges)
                    .SearchByName(serviceParameters.ServiceName)
                    .SearchByCreateAt(serviceParameters.CreatedAt)
                    .SearchByUpdateAt(serviceParameters.UpdatedAt)
                    .SearchByWorkNature(serviceParameters.WorkNature)
                    .SearchByServiceCategory(serviceParameters.ServiceCategory)
                    .SearchByAction(serviceParameters.Action)
                    .SearchByStatus(serviceParameters.Status)
                    .SearchByCarCategory(serviceParameters.CarCategoryName)
                    .SearchByCarPart(serviceParameters.CarPartName)
                    .CountAsync();


            return new PagedList<Service>(
                services,
                count,
                serviceParameters.PageNumber,
                serviceParameters.PageSize);
        }

        public async Task<IEnumerable<Service>> GetServiceByPackageHistoryIdsAsync(IEnumerable<Guid> pacakgeHistoryIds, bool trackChanges)
        {
            return await FindByCondition(x => x.PackageHistories.Any(x => pacakgeHistoryIds.Contains(x.Id)), trackChanges).ToListAsync();
        }

        public async Task<PagedList<Service>> GetServiceByCarCategory(Guid carCategoryId, ServiceParameters serviceParameters,bool trackChanges, string? include = default)
        {
          var services =  await FindByCondition(s => s.CarCategoryId.Equals(carCategoryId), trackChanges).IsInclude(include).ToListAsync();

            return PagedList<Service>.ToPagedList(
                services,
                serviceParameters.PageNumber,
                serviceParameters.PageSize
                );
        }

        public async Task<PagedList<Service>> GetServiceByCarModel(Guid carModelId, ServiceParameters serviceParameters,bool trackChanges)
        {
            var services = await FindByCondition(s => s.CarCategoryId.Equals(RepositoryContext.CarModels.Where(cm => cm.Id.Equals(carModelId)).Select(cm => cm.CarCategoryId)), trackChanges).ToListAsync();
            return PagedList<Service>.ToPagedList(
                services,
                serviceParameters.PageNumber,
                serviceParameters.PageSize
                );
        }
    }
}
