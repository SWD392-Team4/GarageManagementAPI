using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductAtGarageRepository
    {
        public Task CreateProductAtGarageAsync(ProductAtGarage productAtGarage);
        Task<ProductAtGarage?> GetProductAtWarehouse(Guid productAtWarehouseId, bool trackChanges, string? include = default);
        Task<PagedList<ProductAtGarage>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = default);
    }
}
