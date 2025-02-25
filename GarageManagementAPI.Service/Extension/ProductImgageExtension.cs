using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ProductImg;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductImgageExtension
    {
        public static Result<ProductImage> OkResult(this ProductImage productImg)
            => Result<ProductImage>.Ok(productImg);

        public static Result<ProductImageDto> CreatedResult(this ProductImageDto productImageDto)
            => Result<ProductImageDto>.Created(productImageDto);

        public static Result<ProductImage> NotFoundId(this ProductImage? productImage, Guid productId)
            => Result<ProductImage>.NotFound([ProductImgErrors.GetProductImageNotFoundWithIdError(productId)]);

        public static Result<ProductImage> NotFoundError()
          => Result<ProductImage>.NotFound([ProductImgErrors.GetProductImageNotFoundError()]);
    }
}
