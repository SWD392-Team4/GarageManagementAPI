using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.ProductAtWarehouse;

namespace GarageManagementAPI.Service.Extension
{
    public static class ProductAtWarehouseExtension
    {
        public static Result<ProductAtWarehouse>  OkResult(this ProductAtWarehouse productAtWarehouse) 
            => Result<ProductAtWarehouse>.Ok(productAtWarehouse);
        public static Result<ProductAtWarehouseDto> OkResult(this ProductAtWarehouseDto productAtWarehouseDto)
            => Result<ProductAtWarehouseDto>.Ok(productAtWarehouseDto);
        public static Result<ProductAtWarehouseDto> CreatedResult(this ProductAtWarehouseDto productAtWarehouseDto)
            =>  Result<ProductAtWarehouseDto>.Created(productAtWarehouseDto);
        public static Result<ProductAtWarehouse> NotFoundResult(this ProductAtWarehouse? productAtWarehouse, Guid productAtWarehouseId)
            => Result<ProductAtWarehouse>.NotFound([ProductAtWarehouseErrors.ProductAtWarehouseNotFoundError(productAtWarehouseId)]);
        public static Result<ProductAtWarehouse> NotFoundWithGoodsReceidResult(this ProductAtWarehouse? productAtWarehouse, Guid goodsreceived)     
            => Result<ProductAtWarehouse>.NotFound([ProductAtWarehouseErrors.GoodsReceivedDetailNotFoundError(goodsreceived)]);
        
    }
}
