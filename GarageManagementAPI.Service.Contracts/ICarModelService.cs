using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarModelService
    {
        public Task<Result<CarModelDto>> GetCarModel(Guid id, bool trackChanges, string include);

        public Task<Result<IEnumerable<CarModelDto>>> GetCarModels(CarModelParameters carModeParameters, bool trackChanges, string include);

        public Task<Result<CarModelDto>> CreateCarModels(CarModelDtoForCreate carModelDtoForCreate);

        public Task<Result> UpdateCarModel(Guid id, CarModelDtoForUpdate carModelDtoForUpdate, bool trackChanges);
    }
}
