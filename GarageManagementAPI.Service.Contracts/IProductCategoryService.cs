using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductCategoryService
    {
        public Task<Result<ExpandoObject>> GetProductCategoryByIdAsync(Guid productCategoryId, ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductsByIdCategoryAsync(Guid productCategoryId, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null);
        public Task<Result<ProductCategoryDtoForUpdate>> GetProductCategoryForPartiallyUpdate(Guid productCategoryId, bool trackChanges);
        public Task<Result<ProductCategoryDto>> CreateProductCategoryAsync(ProductCategoryDtoForCreation productCategoryDtoForCreation);
        public Task<Result> UpdateProductCategory(Guid productCategoryId, ProductCategoryDtoForUpdate productCategoryDtoForUpdate, bool trackChanges);
    }
}
