using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateServiceAsync(Service service)
        {
            await base.CreateAsync(service);
        }
        public void UpdateServiceAsync(Service service)
        {
            base.Update(service);
        }

        public async Task<Service?> GetServiceByIdAsync(Guid serviceId, bool trackChanges, string? include = null)
        {
            var service = include is null ?
            await FindByCondition(u => u.Id.Equals(serviceId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(u => u.Id.Equals(serviceId), trackChanges).Include(include).SingleOrDefaultAsync();

            return service;
        }

        public async Task<Service?> GetServiceByIdAndNameAsync(string name, Guid? serviceId, bool trackChanges)
        {
            var service = serviceId is null ?
            await FindByCondition(s => s.ServiceName.Equals(name), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(s => s.Id.Equals(serviceId) && s.ServiceName.ToLower().Equals(name.ToLower()), trackChanges).SingleOrDefaultAsync();

            return service;
        }

        public async Task<PagedList<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách Services theo các điều kiện
            var servicesQuery = FindByCondition(s =>
                    (string.IsNullOrEmpty(serviceParameters.ServiceName) || s.ServiceName.Contains(serviceParameters.ServiceName)),
                    trackChanges)
                .SearchByName(serviceParameters.ServiceName) // Tìm kiếm theo tên sản phẩm
                .SearchByCreateAt(serviceParameters.CreatedAt) //Tìm kiếm theo CreatedAt
                .SearchByUpdateAt(serviceParameters.UpdatedAt) //Tìm kiếm theo UpdateAt
                .SearchByWorkNature(serviceParameters.WorkNature)
                .SearchByAction(serviceParameters.Action)
                .SearchByStatus(serviceParameters.Status)
                .Sort(serviceParameters.OrderBy)
                .IsInclude(include)
                .SearchByCarCategory(serviceParameters.CarCategoryName)
                .SearchByCarPart(serviceParameters.CarPartName)
                .AsQueryable();

            // Lấy danh sách sản phẩm sau khi phân trang
            var services = await servicesQuery
                .Skip((serviceParameters.PageNumber - 1) * serviceParameters.PageSize)
                .Take(serviceParameters.PageSize)
                .ToListAsync();

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await servicesQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<Service>(
                services,
                count,
                serviceParameters.PageNumber,
                serviceParameters.PageSize
            );
        }

    }
}
