using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarCategoryService
    {
        public Task<Result<CarCategoryDto>> GetCarCategoryAsync(Guid id, bool trackChanges);

        public Task<Result<IEnumerable<CarCategoryDto>>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges);

        public Task<Result<CarCategoryDto>> CreateCarCategoryAsync(CarCategoryDtoForCreate carCategoryDtoForCreate);

        public Task<Result> UpdateCarCategoryAsync(Guid id, CarCategoryDtoForUpdate carCategoryDtoForUpdate, bool trackChanges);
    }
}
