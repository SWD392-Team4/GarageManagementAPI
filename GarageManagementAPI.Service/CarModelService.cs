using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarModel;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Service
{
    public class CarModelService : ICarModelService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public CarModelService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        private async Task<Result<CarModel>> GetByIdAndCheckIfExist(Guid id, bool trackChanges)
        {
            var result = await _repoManager.CarModel.GetCarModelAsync(id, trackChanges);
            if (result == null)
                return Result<CarModel>.NotFound([CarModelErrors.GetCarModelNotFoundError(id)]);

            return Result<CarModel>.Ok(result);
        }

        private async Task<Result> CheckIfExistByNameAndCategoryIdAndBrandIdAndYear(string modelName, Guid brandId, Guid categoryId, DateOnly modelYear)
        {
            var result = await _repoManager.CarModel.FindByCondition(
                e => e.ModelName.Equals(modelName) &&
                e.BrandId.Equals(brandId) &&
                e.CarCategoryId.Equals(categoryId) &&
                e.ModelYear.Equals(modelYear), false).FirstOrDefaultAsync();

            if (result is not null)
                return Result.BadRequest([CarModelErrors.GetCarModelExist(modelName, modelYear, categoryId, brandId)]);

            return Result.Ok();
        }

        public async Task<Result<CarModelDto>> GetCarModel(Guid id, bool trackChanges)
        {
            var checkIfExistResult = await GetByIdAndCheckIfExist(id, trackChanges);

            if (!checkIfExistResult.IsSuccess)
                return Result<CarModelDto>.NotFound(checkIfExistResult.Errors!);

            var carModelEntity = checkIfExistResult.GetValue<CarModel>();

            var carModelDto = _mapper.Map<CarModelDto>(carModelEntity);

            return Result<CarModelDto>.Ok(carModelDto);
        }

        public async Task<Result<IEnumerable<CarModelDto>>> GetCarModels(CarModelParameters carModeParameters, bool trackChanges)
        {
            var carModels = await _repoManager.CarModel.GetCarModelsAsync(carModeParameters, trackChanges);
            var carModelsDto = _mapper.Map<IEnumerable<CarModelDto>>(carModels);

            return Result<IEnumerable<CarModelDto>>.Ok(carModelsDto, carModels.MetaData);
        }

        public async Task<Result<CarModelDto>> CreateCarModels(CarModelDtoForCreate carModelDtoForCreate)
        {
            var checkIfExistWithNameAndCategoryAndBrandAndYearResult = await CheckIfExistByNameAndCategoryIdAndBrandIdAndYear(carModelDtoForCreate.ModelName, carModelDtoForCreate.BrandId, carModelDtoForCreate.CarCategoryId, carModelDtoForCreate.ModelYear);

            if (!checkIfExistWithNameAndCategoryAndBrandAndYearResult.IsSuccess)
                return Result<CarModelDto>.BadRequest(checkIfExistWithNameAndCategoryAndBrandAndYearResult.Errors!);

            var carModelEntity = _mapper.Map<CarModel>(carModelDtoForCreate);

            carModelEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carModelEntity.CreatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carModelEntity.Status = CarModelStatus.Active;
            await _repoManager.CarModel.CreateAsync(carModelEntity);
            await _repoManager.SaveAsync();

            var carModelDto = _mapper.Map<CarModelDto>(carModelEntity);

            return Result<CarModelDto>.Ok(carModelDto);
        }

        public async Task<Result> UpdateCarModel(Guid id, CarModelDtoForUpdate carModelDtoForUpdate, bool trackChanges)
        {
            var checkIfExistResult = await GetByIdAndCheckIfExist(id, trackChanges);

            if (!checkIfExistResult.IsSuccess)
                return Result<CarModelDto>.NotFound(checkIfExistResult.Errors!);

            var carModelEntity = checkIfExistResult.GetValue<CarModel>();

            if (!carModelEntity.ModelName.Equals(carModelDtoForUpdate.ModelName)
                && !carModelEntity.BrandId.Equals(carModelDtoForUpdate.BrandId)
                && !carModelEntity.CarCategoryId.Equals(carModelEntity.CarCategoryId)
                && !carModelEntity.ModelYear.Equals(carModelEntity.ModelYear))
            {
                var checkIfExistWithNameAndCategoryAndBrandAndYearResult = await CheckIfExistByNameAndCategoryIdAndBrandIdAndYear(carModelDtoForUpdate.ModelName, carModelDtoForUpdate.BrandId, carModelDtoForUpdate.CarCategoryId, carModelDtoForUpdate.ModelYear);

                if (!checkIfExistResult.IsSuccess)
                    return Result.BadRequest(checkIfExistWithNameAndCategoryAndBrandAndYearResult.Errors!);
            }

            _mapper.Map(carModelDtoForUpdate, carModelEntity);
            carModelEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
