using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductCategory;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductCategoryExtension
    {
        public static Result<ProductCategory> OkResult(this ProductCategory productCategory)
   => Result<ProductCategory>.Ok(productCategory);

        public static Result<ProductCategoryDto> OkResult(this ProductCategoryDto productCategoryDto)
            => Result<ProductCategoryDto>.Ok(productCategoryDto);

        public static Result<IEnumerable<Product>> OkResult(this IEnumerable<Product> products)
            => Result<IEnumerable<Product>>.Ok(products);

        public static Result<ProductCategoryDto> CreatedResult(this ProductCategoryDto productCategoryDto)
            => Result<ProductCategoryDto>.Created(productCategoryDto);

        public static Result<ProductCategory> NotFound(this ProductCategory? productCategory, Guid productCategoryId)
            => Result<ProductCategory>.NotFound([ProductCategoryErrors.GetProductCategoryNotFoundWithIdError(productCategoryId)]);

        public static Result<IEnumerable<Product>> NotFound(this IEnumerable<Product> productCategory)
    => Result<IEnumerable<Product>>.NotFound([ProductErrors.GetProductNotFoundWithError()]);
    }
}
