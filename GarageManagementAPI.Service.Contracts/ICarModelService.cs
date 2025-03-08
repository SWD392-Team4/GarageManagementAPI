using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarModelService
    {
        public Task<Result<ExpandoObject>> GetCarModel(Guid id, bool trackChanges, string? fields = null, string? include = null);

        public Task<Result<IEnumerable<ExpandoObject>>> GetCarModels(CarModelParameters carModeParameters, bool trackChanges, string? include = null);

        public Task<Result<ExpandoObject>> CreateCarModels(CarModelDtoForCreate carModelDtoForCreate, string? fields = null);

        public Task<Result> UpdateCarModel(Guid id, CarModelDtoForUpdate carModelDtoForUpdate, bool trackChanges);
    }
}
