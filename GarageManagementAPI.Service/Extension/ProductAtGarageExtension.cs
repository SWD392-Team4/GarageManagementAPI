using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage;


namespace GarageManagementAPI.Service.Extension
{
    public static class ProductAtGarageExtension
    {
        public static Result<ProductAtGarageDto> CreateResult(this ProductAtGarageDto productAtGarageDto) 
            => Result<ProductAtGarageDto>.Created(productAtGarageDto);

        public static Result<ProductAtGarage> OkResukt(this ProductAtGarage productAtGarage)
            => Result<ProductAtGarage>.Ok(productAtGarage);

        public static Result<ProductAtGarage> NotFound(this ProductAtGarage? productAtGarage, Guid productAtWarehouseId)
            => Result<ProductAtGarage>.NotFound([ProductAtGarageErrors.GetProductAtGarageNotFound(productAtWarehouseId)]);
    }
}
