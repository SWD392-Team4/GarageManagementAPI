using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using GarageManagementAPI.Service.Extension;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

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
            _dataShaper= dataShaper;
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
            var check = await CheckIfBrandExistByName(brandDtoForCreation);
            if (check)
                return Result<BrandDto>.BadRequest([BrandErrors.GetBrandNameAlreadyExistError(brandDtoForCreation)]);

            var brandEntity = _mapper.Map<Brand>(brandDtoForCreation);

            brandEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            brandEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            brandEntity.Status = SystemStatus.Inactive;

            await _repoManager.Brand.CreateBrandAsync(brandEntity);
            await _repoManager.SaveAsync();

            var brandDtoToReturn = _mapper.Map<BrandDto>(brandEntity);

            return brandDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateBrand(Guid brandId, BrandDtoForUpdate brandDtoForUpdate, bool trackChanges)
        {
            var brandResult = await GetAndCheckIfBrandExist(brandId, trackChanges);
            if (!brandResult.IsSuccess)
                return Result<WorkplaceDto>.Failure(brandResult.StatusCode, brandResult.Errors!);
            var brandEntity = brandResult.GetValue<Brand>();

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


        private async Task<bool> CheckIfBrandExistByName(BrandDtoForCreation brandDtoForCreation)
        {

            var name = brandDtoForCreation.BrandName!.Trim();

            var exists = await _repoManager.Brand.FindByCondition(x =>
                x.BrandName.Trim().Equals(name),
                false).AnyAsync();

            return exists;
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
