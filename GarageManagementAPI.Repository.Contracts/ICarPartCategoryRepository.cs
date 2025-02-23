using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarPartCategoryRepository
    {
        Task<CarPartCategory?> GetCarPartCategoryByIdAsync(Guid carPartCategoryId, bool trackChanges, string? include = default);
        Task<CarPartCategory?> GetCarPartCategoryByIdAndNameAsync(string name, Guid? carPartCategoryId, bool trackChanges);
        Task<PagedList<CarPartCategory>> GetCarPartCategoriesAsync(CarPartCategoryParameters carPartCategoryParameters, bool trackChanges, string? include = default);
        Task CreateCarPartCategoryAsync(CarPartCategory carPartCategory);
        void UpdateCarPartCategoryAsync(CarPartCategory carPartCategory);
    }
}
