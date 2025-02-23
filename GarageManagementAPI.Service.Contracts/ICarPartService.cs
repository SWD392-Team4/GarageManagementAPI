using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarPartService
    {
        public Task<Result<ExpandoObject>> GetCarPartAsync(Guid carPartId, CarPartParameters carPartParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetCarPartsAsync(CarPartParameters carPartParameters, bool trackChanges, string? include = null);
        public Task<Result<CarPartDtoForUpdate>> GetCarPartForPartiallyUpdate(Guid carPartId, bool trackChanges);
        public Task<Result<CarPartDto>> CreateCarPartAsync(CarPartDtoForCreation carPartDtoForCreation);
        public Task<Result> UpdateCarPart(Guid carPartId, CarPartDtoForUpdate carPartDtoForUpdate, bool trackChanges);
    }
}
