using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.ErrorsConstant.CarPart;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class CarPartExtension
    {
        public static Result<CarPart> OkResult(this CarPart carPart)
            => Result<CarPart>.Ok(carPart);
        public static Result<CarPartDto> OkResult(this CarPartDto carPartDto)
            => Result<CarPartDto>.Ok(carPartDto);
        public static Result<CarPartDto> CreatedResult(this CarPartDto carPartDto)
            => Result<CarPartDto>.Created(carPartDto);
        public static Result<CarPart> NotFound(Guid carPartId)
            => Result<CarPart>.NotFound([CarPartErrors.GetCarPartNotFoundWithIdError(carPartId)]);
    }
}
