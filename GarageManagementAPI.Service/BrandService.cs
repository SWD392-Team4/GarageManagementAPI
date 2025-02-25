using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;

namespace GarageManagementAPI.Service
{
    public class BrandService : IBrandService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public BrandService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }


        public async Task<Result<IEnumerable<ExpandoObject>>> GetBrandsAsync(BrandParameters brandParameters, bool trackChanges, string? include = null)
        {
            var brandsWithMetadata = await _repoManager.Brand.GetBrandsAsync(brandParameters, trackChanges, include);

            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brandsWithMetadata);

            var brandsShaped = _dataShaper.Brand.ShapeData(brandsDto, brandParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(brandsShaped, brandsWithMetadata.MetaData);
        }

        public async Task<Result<ExpandoObject>> GetBrandAsync(Guid brandId, BrandParameters brandParameters, bool trackChanges, string? include = null)
        {
            var brandResult = await GetAndCheckIfBrandExist(brandId, trackChanges);

            if (!brandResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(brandResult.Errors!);

            var brandEntity = brandResult.GetValue<Brand>();

            var brandsDto = _mapper.Map<BrandDto>(brandEntity);

            var brandShaped = _dataShaper.Brand.ShapeData(brandsDto, brandParameters.Fields);

            return Result<ExpandoObject>.Ok(brandShaped);
        }

        public async Task<Result<BrandDto>> CreateBrandAsync(BrandDtoForCreation brandDtoForCreation)
        {
            var check = await GetAndCheckIfBrandExistByName(brandDtoForCreation.BrandName);
            if (check)
                return Result<BrandDto>.BadRequest([BrandErrors.GetBrandNameAlreadyExistError(brandDtoForCreation)]);

            var brandEntity = _mapper.Map<Brand>(brandDtoForCreation);

            brandEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            brandEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            brandEntity.Status = BrandStatus.Inactive;

            await _repoManager.Brand.CreateBrandAsync(brandEntity);
            await _repoManager.SaveAsync();

            var brandDtoToReturn = _mapper.Map<BrandDto>(brandEntity);

            return brandDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateBrand(Guid brandId, BrandDtoForUpdate brandDtoForUpdate, bool trackChanges)
        {
            var checkBrandIsExistResult = await GetAndCheckIfBrandExist(brandId, trackChanges);
            var checkBrandNameIsEXist = await GetAndCheckIfBrandExistByName(brandDtoForUpdate.BrandName, brandId);
            if (checkBrandNameIsEXist)
                return Result<BrandDto>.BadRequest([BrandErrors.GetBrandNameUpdateAlreadyExistError(brandDtoForUpdate)]);
            if (!checkBrandIsExistResult.IsSuccess)
                return Result<BrandDto>.Failure(checkBrandIsExistResult.StatusCode, checkBrandIsExistResult.Errors!);
            var brandEntity = checkBrandIsExistResult.GetValue<Brand>();

            _mapper.Map(brandDtoForUpdate, brandEntity);

            brandEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }
        public async Task<Result<BrandDtoForUpdate>> GetBrandForPartiallyUpdate(Guid brandId, bool trackChanges)
        {
            var brandResult = await GetAndCheckIfBrandExist(brandId, trackChanges);
            if (!brandResult.IsSuccess)
                return Result<BrandDtoForUpdate>.Failure(brandResult.StatusCode, brandResult.Errors!);

            var brandEntity = brandResult.GetValue<Brand>();

            var brandDtoForUpdate = _mapper.Map<BrandDtoForUpdate>(brandEntity);

            return Result<BrandDtoForUpdate>.Ok(brandDtoForUpdate);
        }

        private async Task<bool> GetAndCheckIfBrandExistByName(string name, Guid? brandId = null)
        {
            var brand = await _repoManager.Brand.GetBrandByIdAndNameAsync(name, brandId, false);
            if (brand == null) return false;
            return true;
        }
        private async Task<Result<Brand>> GetAndCheckIfBrandExist(Guid brandId, bool trackChanges)
        {
            var brand = await _repoManager.Brand.GetBrandByIdAsync(brandId, trackChanges);
            if (brand == null)
                return brand.NotFound(brandId);

            return brand.OkResult();
        }
    }
}
