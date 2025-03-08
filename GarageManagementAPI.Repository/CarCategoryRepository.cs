using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class CarCategoryRepository : RepositoryBase<CarCategory>, ICarCategoryRepository
    {
        public CarCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async new Task CreateAsync(CarCategory carCategory)
        {
            carCategory.CreatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carCategory.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carCategory.Status = CarCategoryStatus.Active;
            await base.CreateAsync(carCategory);
        }

        public async Task<PagedList<CarCategory>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges)
        {
            var carCategories = await FindAll(trackChanges)
                .FilterByCategory(carCategoryParameters.Category)
                .FilterByDescription(carCategoryParameters.Description)
                .FilterByStatus(carCategoryParameters.Status)
                .FilterByCreatedAt(carCategoryParameters.CreatedAt)
                .FilterByUpdatedAt(carCategoryParameters.UpdatedAt)
                .Sort(carCategoryParameters.OrderBy)
                .Skip((carCategoryParameters.PageNumber - 1) * carCategoryParameters.PageSize)
                .Take(carCategoryParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .FilterByCategory(carCategoryParameters.Category)
                .FilterByDescription(carCategoryParameters.Description)
                .FilterByStatus(carCategoryParameters.Status)
                .FilterByCreatedAt(carCategoryParameters.CreatedAt)
                .FilterByUpdatedAt(carCategoryParameters.UpdatedAt)
                .CountAsync();


            return PagedList<CarCategory>.ToPagedList(
                carCategories,
                carCategoryParameters.PageNumber,
                carCategoryParameters.PageSize);
        }

        public async Task<CarCategory?> GetCarCategoryAsync(string category, bool trackChanges)
        {
            return await FindByCondition(e => e.Category.Equals(category), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<CarCategory?> GetCarCategoryAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
