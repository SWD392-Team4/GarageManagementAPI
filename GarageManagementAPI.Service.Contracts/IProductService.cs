using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductService
    {
        public Task<Result<ExpandoObject>> GetProductByIdAsync(Guid productId, ProductParameters productParameters, bool trackChanges, string? include = null);
        public Task<Result<ExpandoObject>> GetProductByBarcodeAsync(string productId, ProductParameters productParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null);
        public Task<Result<ProductDtoForUpdate>> GetProductForPartiallyUpdate(Guid productId, bool trackChanges, string? include = null);
        public Task<Result<ProductDto>> CreateProductAsync(ProductDtoForCreation productDtoForCreation);
        public Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate productDtoForUpdate, bool trackChanges, string? include = null);
    }
}