using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using GarageManagementAPI.Shared.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Service.Extension
{
    public static class BrandExtension
    {
        public static Result<Brand> OkResult(this Brand Brand)
           => Result<Brand>.Ok(Brand);

        public static Result<BrandDto> OkResult(this BrandDto BrandDto)
            => Result<BrandDto>.Ok(BrandDto);

        public static Result<BrandDto> CreatedResult(this BrandDto BrandDto)
            => Result<BrandDto>.Created(BrandDto);

        public static Result<Brand> NotFound(this Brand? Brand, Guid BrandId)
            => Result<Brand>.NotFound([BrandErrors.GetBrandNotFoundError(BrandId)]);
    }
}
