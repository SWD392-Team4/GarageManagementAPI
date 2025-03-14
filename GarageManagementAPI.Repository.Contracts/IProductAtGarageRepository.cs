using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductAtGarageRepository
    {
        public Task CreateProductAtGarageAsync(ProductAtGarage productAtGarage);
        Task<ProductAtGarage?> GetProductAtGarage(Guid productAtWarehouseId, bool trackChanges, string? include = default);
        Task<ProductAtGarage?> GetProductAtGarage(Guid productId, bool trackChanges);
        Task<PagedList<ProductAtGarage>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = default);
        void UpdateProductGarage(ProductAtGarage productAtGarage);
    }
}
