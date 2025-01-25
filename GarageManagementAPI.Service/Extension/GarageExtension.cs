using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Shared.Constant.Garage;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class GarageExtension
    {
        public static Result<Garage> ToOkResult(this Garage garage)
            => Result<Garage>.Ok(garage);

        public static Result<GarageDto> ToOkResult(this GarageDto garageDto)
            => Result<GarageDto>.Ok(garageDto);

        public static Result<GarageDto> ToCreatedResult(this GarageDto garageDto)
            => Result<GarageDto>.Created(garageDto);

        public static Result<GarageForUpdateDto> ToOkResult(this GarageForUpdateDto garageForUpdateDto)
            => Result<GarageForUpdateDto>.Ok(garageForUpdateDto);

        public static Result<Garage> GarageNotFound(this Garage? garage, Guid garageId)
            => Result<Garage>.NotFound([GarageErrors.GetGarageNotFoundError(garageId)]);
    }
}
