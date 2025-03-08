using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarCategoryRepository : IRepositoryBase<CarCategory>
    {
        public Task<PagedList<CarCategory>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges);

        public Task<CarCategory?> GetCarCategoryAsync(Guid id, bool trackChanges);

        public Task<CarCategory?> GetCarCategoryAsync(string category, bool trackChanges);
    }
}
