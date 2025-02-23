
using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarPartCategoryService
    {
        public Task<Result<ExpandoObject>> GetCarPartCategoryAsync(Guid Id, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetCarPartCategoriesAsync(CarPartCategoryParameters carPartCategproParameters, bool trackChanges, string? include = null);
        public Task<Result<CarPartCategoryDtoForUpdate>> GetCarPartCategoryForPartiallyUpdate(Guid brandId, bool trackChanges);
        public Task<Result<CarPartCategoryDto>> CreateCarPartCategoryAsync(CarPartCategoryDtoForCreation carPartCategoryDto);
        public Task<Result> UpdateCarPartCategory(Guid carPartCategoryId, CarPartCategoryDtoForUpdate carPartCategoryDtoForUpdate, bool trackChange);
    }
}
