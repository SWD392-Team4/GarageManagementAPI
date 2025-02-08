using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Product>> GetProductsAsync(ProductParameters userParameters, bool trackChanges, bool isEmployee, string? include = null)
        {
            throw new NotImplementedException();
        }
    }
}
