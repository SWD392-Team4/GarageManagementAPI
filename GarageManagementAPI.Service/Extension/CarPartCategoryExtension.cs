using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.ErrorsConstant.CarPartCategoryCategory;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class CarPartCategoryExtension
    {
        public static Result<CarPartCategory> OkResult(this CarPartCategory carPartCategory)
           => Result<CarPartCategory>.Ok(carPartCategory);

        public static Result<CarPartCategoryDto> OkResult(this CarPartCategoryDto carPartCategoryDto)
            => Result<CarPartCategoryDto>.Ok(carPartCategoryDto);

        public static Result<CarPartCategoryDto> CreatedResult(this CarPartCategoryDto carPartCategoryDto)
            => Result<CarPartCategoryDto>.Created(carPartCategoryDto);

        public static Result<CarPartCategory> NotFound(this CarPartCategory? CarPartCategory, Guid carPartCategoryId)
            => Result<CarPartCategory>.NotFound([CarPartCategoryErrors.GetCarPartCategoryNotFoundWithIdError(carPartCategoryId)]);
    }
}
