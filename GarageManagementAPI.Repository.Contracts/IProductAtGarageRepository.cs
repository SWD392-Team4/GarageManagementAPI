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

        Task<IEnumerable<ProductAtGarage>> GetProductAtGarages(Guid garageId, bool trackChanges, string? include = default);
        Task<List<(Guid ProductAtGarageId, int DeductedQuantity)>> DeductProductQuantityFromGarageAsync(
     Guid productId, Guid? garageId, int quantity);

        public Task<int> GetTotalStockForProduct(Guid productId, Guid? garageId);

        public Task<Dictionary<Guid, int>> GetTotalQuantityByProductIdAsync();
        void UpdateProductGarage(ProductAtGarage productAtGarage);
    }
}
