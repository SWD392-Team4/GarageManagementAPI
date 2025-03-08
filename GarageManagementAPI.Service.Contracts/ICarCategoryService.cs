using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarCategoryService
    {
        public Task<Result<ExpandoObject>> GetCarCategoryAsync(Guid id, bool trackChanges, string? fields = null);

        public Task<Result<IEnumerable<ExpandoObject>>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges);

        public Task<Result<ExpandoObject>> CreateCarCategoryAsync(CarCategoryDtoForCreate carCategoryDtoForCreate, string? fields = null);

        public Task<Result> UpdateCarCategoryAsync(Guid id, CarCategoryDtoForUpdate carCategoryDtoForUpdate, bool trackChanges);
    }
}
