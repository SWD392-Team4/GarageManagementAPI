using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductExtension
    {
        public static Result<Product> OkResult(this Product product)
          => Result<Product>.Ok(product);

        public static Result<ProductDtoWithPrice> OkResultWithPrice(this ProductDtoWithPrice product)
  => Result<ProductDtoWithPrice>.Ok(product);

        public static Result<ProductDto> OkResult(this ProductDto productDto)
            => Result<ProductDto>.Ok(productDto);

        public static Result<ProductDto> CreatedResult(this ProductDto productDto)
            => Result<ProductDto>.Created(productDto);

        public static Result<Product> NotFoundId(this Product? product, Guid productId)
            => Result<Product>.NotFound([ProductErrors.GetProductNotFoundIdError(productId)]);

        public static Result<ProductDtoWithPrice> NotFoundWithPriceId(this ProductDtoWithPrice? product, Guid productId)
        => Result<ProductDtoWithPrice>.NotFound([ProductErrors.GetProductNotFoundIdError(productId)]);

        public static Result<ProductDtoWithPrice> NotFoundBarCode(this ProductDtoWithPrice? product, string barcode)
        => Result<ProductDtoWithPrice>.NotFound([ProductErrors.GetProductByBarcodeNotFoundError(barcode)]);
    }
}
