using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductHistoryExtension
    {
        public static Result<ProductHistory> OkResult(this ProductHistory product)
         => Result<ProductHistory>.Ok(product);

        public static Result<ProductHistoryDto> OkResult(ProductHistoryDto productDto)
            => Result<ProductHistoryDto>.Ok(productDto);

        public static Result<ProductHistoryDto> CreatedResult(this ProductHistoryDto productDto)
            => Result<ProductHistoryDto>.Created(productDto);

        public static Result<ProductHistory> NotFoundId(this ProductHistory? product, Guid productId)
            => Result<ProductHistory>.NotFound([ProductHistoryErrors.GetProductHistoryNotFoundWithIdError(productId)]);

        public static Result<ProductHistoryDto> NotFoundId(Guid productId)
     => Result<ProductHistoryDto>.NotFound([ProductHistoryErrors.GetProductHistoryNotFoundWithIdError(productId)]);

        public static Result<ProductHistory> NotFoundError()
          => Result<ProductHistory>.NotFound([ProductHistoryErrors.GetProductHistoryNotFoundError()]);
    }
}
