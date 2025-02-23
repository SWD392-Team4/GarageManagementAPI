using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarPartRepository
    {
        Task<CarPart?> GetCarPartByIdAsync(Guid carPartId, bool trackChanges, string? include = default);
        Task<CarPart?> GetCarPartByIdAndNameAsync(string name, Guid? carPartId, bool trackChanges);
        Task<PagedList<CarPart>> GetCarPartsAsync(CarPartParameters carPartParameters, bool trackChanges, string? include = default);
        Task CreateCarPartAsync(CarPart CarPart);
        void UpdateCarPartAsync(CarPart CarPart);
    }
}
