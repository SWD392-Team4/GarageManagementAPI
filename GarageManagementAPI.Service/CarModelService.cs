using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using GarageManagementAPI.Shared.ErrorsConstant.CarModel;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using System.Dynamic;

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

        public async Task<Result<ExpandoObject>> GetCarModel(Guid id, bool trackChanges, string? fields, string? include = null)
        {
            var carModelEntity = await _repoManager.CarModel.GetCarModelAsync(id, trackChanges, include);
            if (carModelEntity is null)
                return Result<ExpandoObject>.NotFound([CarModelErrors.GetCarModelNotFoundError(id)]);

            var carModelDto = _mapper.Map<CarModelDto>(carModelEntity);

            var carModelDtoShaped = _dataShaper.CarModel.ShapeData(carModelDto, fields);

            return Result<ExpandoObject>.Ok(carModelDtoShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetCarModels(CarModelParameters carModeParameters, bool trackChanges, string? include = null)
        {
            var carModels = await _repoManager.CarModel.GetCarModelsAsync(carModeParameters, trackChanges, include);

            var carModelsDtos = _mapper.Map<IEnumerable<CarModelDto>>(carModels);

            var carModelDtosShaped = _dataShaper.CarModel.ShapeData(carModelsDtos, carModeParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(carModelDtosShaped, carModels.MetaData);
        }

        public async Task<Result<ExpandoObject>> CreateCarModels(CarModelDtoForCreate carModelDtoForCreate, string? fields)
        {
            var validateInputResult = await ValidateInputForCreate(carModelDtoForCreate);
            if (!validateInputResult.IsSuccess)
                return Result<ExpandoObject>.Failure(validateInputResult);

            var carModelEntity = _mapper.Map<CarModel>(carModelDtoForCreate);

            await _repoManager.CarModel.CreateCarModelsAsync(carModelEntity);
            await _repoManager.SaveAsync();

            var carModelDto = _mapper.Map<CarModelDto>(carModelEntity);

            var carModelDtoShaped = _dataShaper.CarModel.ShapeData(carModelDto, fields);

            return Result<ExpandoObject>.Ok(carModelDtoShaped);
        }

        private async Task<Result> ValidateInputForCreate(CarModelDtoForCreate carModelDtoForCreate)
        {
            var modelName = carModelDtoForCreate.ModelName;
            var brandId = carModelDtoForCreate.BrandId!.Value;
            var carCategoryId = carModelDtoForCreate.CarCategoryId!.Value;
            var modelYear = carModelDtoForCreate.ModelYear!.Value;

            var isBrandIdExist = await _repoManager.Brand.GetBrandByIdAsync(brandId, false);
            if (isBrandIdExist is null)
                return Result.NotFound([BrandErrors.GetBrandNotFoundWithIdError(brandId)]);

            var isCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(carCategoryId, false);
            if (isCarCategoryExist is null)
                return Result.NotFound([CarCategoryErrors.GetCarCategoryNotFoundError(carCategoryId)]);

            var checkIfExistWithNameAndCategoryAndBrandAndYearResult = await _repoManager.CarModel.GetCarModelAsync(modelName!, brandId, carCategoryId, modelYear, false);
            if (checkIfExistWithNameAndCategoryAndBrandAndYearResult is not null)
                return Result.Conflict([CarModelErrors.GetCarModelExist(modelName!, modelYear, carCategoryId, brandId)]);

            return Result.Ok();
        }

        public async Task<Result> UpdateCarModel(Guid id, CarModelDtoForUpdate carModelDtoForUpdate, bool trackChanges)
        {
            var validateInputResult = await ValidateInputForUpdate(id, trackChanges, carModelDtoForUpdate);

            if (!validateInputResult.IsSuccess)
                return validateInputResult;

            var carModelEntity = validateInputResult.GetValue<CarModel>();

            _mapper.Map(carModelDtoForUpdate, carModelEntity);
            carModelEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.Ok();
        }
        private async Task<Result<CarModel>> ValidateInputForUpdate(Guid id, bool trackChanges, CarModelDtoForUpdate carModelDtoForUpdate)
        {
            var modelName = carModelDtoForUpdate.ModelName;
            var brandId = carModelDtoForUpdate.BrandId!.Value;
            var carCategoryId = carModelDtoForUpdate.CarCategoryId!.Value;
            var modelYear = carModelDtoForUpdate.ModelYear!.Value;

            var isBrandIdExist = await _repoManager.Brand.GetBrandByIdAsync(brandId, false);
            if (isBrandIdExist is null)
                return Result<CarModel>.NotFound([BrandErrors.GetBrandNotFoundWithIdError(brandId)]);

            var isCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(carCategoryId, false);
            if (isCarCategoryExist is null)
                return Result<CarModel>.NotFound([CarCategoryErrors.GetCarCategoryNotFoundError(carCategoryId)]);

            var checkIfExistResult = await _repoManager.CarModel.GetCarModelAsync(id, trackChanges);
            if (checkIfExistResult is null)
                return Result<CarModel>.NotFound([CarModelErrors.GetCarModelNotFoundError(id)]);

            var checkIfExistWithNameAndCategoryAndBrandAndYearResult = await _repoManager.CarModel.GetCarModelAsync(modelName!, brandId, carCategoryId, modelYear, false);
            if (checkIfExistWithNameAndCategoryAndBrandAndYearResult is not null && !checkIfExistWithNameAndCategoryAndBrandAndYearResult.Id.Equals(id))
                return Result<CarModel>.Conflict([CarModelErrors.GetCarModelExist(modelName!, modelYear, carCategoryId, brandId)]);

            return Result<CarModel>.Ok(checkIfExistResult!);
        }
    }
}
