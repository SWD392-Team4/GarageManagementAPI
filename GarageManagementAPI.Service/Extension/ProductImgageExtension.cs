using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ProductImg;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductImgageExtension
    {
        public static Result<ProductImageDto> OkResult(ProductImageDto productDto)
            => Result<ProductImageDto>.Ok(productDto);

        public static Result<ProductImageDto> CreatedResult(this ProductImageDto productDto)
            => Result<ProductImageDto>.Created(productDto);

        public static Result<ProductImage> NotFoundId(this ProductImage? product, Guid productId)
            => Result<ProductImage>.NotFound([ProductImgErrors.GetProductImageNotFoundWithIdError(productId)]);

        public static Result<ProductImageDto> NotFoundId(Guid productId)
     => Result<ProductImageDto>.NotFound([ProductImgErrors.GetProductImageNotFoundWithIdError(productId)]);

        public static Result<ProductImage> NotFoundError()
          => Result<ProductImage>.NotFound([ProductImgErrors.GetProductImageNotFoundError()]);
    }
}
