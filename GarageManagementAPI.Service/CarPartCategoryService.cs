using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.ErrorsConstant.CarPartCategoryCategory;

namespace GarageManagementAPI.Service
{
    public class CarPartCategoryService : ICarPartCategoryService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public CarPartCategoryService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result<CarPartCategoryDto>> CreateCarPartCategoryAsync(CarPartCategoryDtoForCreation carPartCategoryDto)
        {
            var check = await GetAndCheckCarpartCategoryByIdAndName(carPartCategoryDto.PartCategory.Trim());
            if (check)
                return Result<CarPartCategoryDto>.BadRequest([CarPartCategoryErrors.GetCarPartCategoryNameAlreadyExistError(carPartCategoryDto)]);

            var carPartCategoryEntity = _mapper.Map<CarPartCategory>(carPartCategoryDto);

            carPartCategoryEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            carPartCategoryEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            carPartCategoryEntity.Status = CarPartCategoryStatus.Inactive;

            await _repoManager.CarPartCategory.CreateCarPartCategoryAsync(carPartCategoryEntity);
            await _repoManager.SaveAsync();

            var carPartCategoryDtoToReturn = _mapper.Map<CarPartCategoryDto>(carPartCategoryEntity);

            return carPartCategoryDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateCarPartCategory(Guid carPartCategoryId, CarPartCategoryDtoForUpdate carPartCategoryDtoForUpdate, bool trackChanges)
        {
            var checkCarPartIsExistResult = await GetAndCheckCarpartCategoryById(carPartCategoryId, trackChanges);
            var checkCarPartNameIsExistResult = await GetAndCheckCarpartCategoryByIdAndName(carPartCategoryDtoForUpdate.PartCategory, carPartCategoryId);
            if (checkCarPartNameIsExistResult)
                return Result<CarPartDto>.BadRequest([CarPartCategoryErrors.GetCarPartCategoryNameUpdateAlreadyExistError(carPartCategoryDtoForUpdate)]);
            if (!checkCarPartIsExistResult.IsSuccess)
                return Result<CarPartDto>.Failure(checkCarPartIsExistResult.StatusCode, checkCarPartIsExistResult.Errors!);
            var carPartEntity = checkCarPartIsExistResult.GetValue<CarPartCategory>();

            _mapper.Map(carPartCategoryDtoForUpdate, carPartEntity);

            carPartEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetCarPartCategoriesAsync(CarPartCategoryParameters carPartCategproParameters, bool trackChanges, string? include = null)
        {
            var carPartCategorysWithMetadata = await _repoManager.CarPartCategory.GetCarPartCategoriesAsync(carPartCategproParameters, trackChanges, include);

            var carPartCategoriesDto = _mapper.Map<IEnumerable<CarPartCategoryDto>>(carPartCategorysWithMetadata);

            var carPartCategoriesShaped = _dataShaper.CarPartCategory.ShapeData(carPartCategoriesDto, carPartCategproParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(carPartCategoriesShaped, carPartCategorysWithMetadata.MetaData);
        }

        public async Task<Result<ExpandoObject>> GetCarPartCategoryAsync(Guid Id, bool trackChanges, string? include)
        {
            var carPartCategoryResult = await this.GetAndCheckCarpartCategoryById(Id, trackChanges);
            if (!carPartCategoryResult.IsSuccess) return Result<ExpandoObject>.NotFound(carPartCategoryResult.Errors!);

            var carPartCategoryEntity = carPartCategoryResult.GetValue<CarPartCategory>();

            var carPartCategoryDto = _mapper.Map<CarPartCategoryDto>(carPartCategoryEntity);

            var productShaped = _dataShaper.CarPartCategory.ShapeData(carPartCategoryDto, null);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<CarPartCategoryDtoForUpdate>> GetCarPartCategoryForPartiallyUpdate(Guid CarPartCategoryId, bool trackChanges)
        {
            var carPartCategoryResult = await GetAndCheckCarpartCategoryById(CarPartCategoryId, trackChanges);
            if (!carPartCategoryResult.IsSuccess)
                return Result<CarPartCategoryDtoForUpdate>.Failure(carPartCategoryResult.StatusCode, carPartCategoryResult.Errors!);

            var carPartEntity = carPartCategoryResult.GetValue<CarPartCategory>();

            var carPartDtoForUpdate = _mapper.Map<CarPartCategoryDtoForUpdate>(carPartEntity);

            return Result<CarPartCategoryDtoForUpdate>.Ok(carPartDtoForUpdate);
        }

        private async Task<Result<CarPartCategory>> GetAndCheckCarpartCategoryById(Guid id, bool trackChanges)
        {
            var carPartCategory = await _repoManager.CarPartCategory.GetCarPartCategoryByIdAsync(id, trackChanges);
            if (carPartCategory == null) return carPartCategory.NotFound(id);
            return carPartCategory.OkResult();
        }

        private async Task<bool> GetAndCheckCarpartCategoryByIdAndName(string name, Guid? id = null)
        {
            var carPartCategory = await _repoManager.CarPartCategory.GetCarPartCategoryByIdAndNameAsync(name, id, false);
            if (carPartCategory == null) return false;
            return true;
        }
    }
}
