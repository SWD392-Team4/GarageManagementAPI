using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;

namespace GarageManagementAPI.Service
{
    public class CarCategoryService : ICarCategoryService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public CarCategoryService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        private async Task<Result<CarCategory>> GetByIdAndCheckIfExistAsync(Guid id, bool trackChanges)
        {
            var carCategory = await _repoManager.CarCategory.GetCarCategoryAsync(id, trackChanges);

            if (carCategory is null)
                return Result<CarCategory>.NotFound([CarCategoryErrors.GetCarCategoryNotFoundError(id)]);

            return Result<CarCategory>.Ok(carCategory);
        }

        private async Task<Result> CheckIfCarCategoryExistByNameAsync(string name)
        {
            var carCategory = await _repoManager.CarCategory.FindByCondition(e => e.Category.Equals(name), false).FirstOrDefaultAsync();

            if (carCategory is not null)
                return Result.BadRequest([CarCategoryErrors.GetCarCategoryAlreadyExist(name)]);

            return Result.Ok();
        }

        public async Task<Result<CarCategoryDto>> CreateCarCategoryAsync(CarCategoryDtoForCreate carCategoryDtoForCreate)
        {
            var checkIfCarCategoryExistResult = await CheckIfCarCategoryExistByNameAsync(carCategoryDtoForCreate.Category!);

            if (!checkIfCarCategoryExistResult.IsSuccess)
                return Result<CarCategoryDto>.BadRequest(checkIfCarCategoryExistResult.Errors!);

            var carCategoryEntity = _mapper.Map<CarCategory>(carCategoryDtoForCreate);

            carCategoryEntity.CreatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carCategoryEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carCategoryEntity.Status = CarCategoryStatus.Active;
            await _repoManager.CarCategory.CreateCarCategoryAsync(carCategoryEntity);
            await _repoManager.SaveAsync();

            var carCategoryDto = _mapper.Map<CarCategoryDto>(carCategoryEntity);

            return Result<CarCategoryDto>.Ok(carCategoryDto);
        }

        public async Task<Result<CarCategoryDto>> GetCarCategoryAsync(Guid id, bool trackChanges)
        {
            var checkIfExistResult = await GetByIdAndCheckIfExistAsync(id, trackChanges);

            if (!checkIfExistResult.IsSuccess)
                return Result<CarCategoryDto>.NotFound(checkIfExistResult.Errors!);

            var carCategory = checkIfExistResult.GetValue<CarCategory>();

            var carCategoryDto = _mapper.Map<CarCategoryDto>(carCategory);

            return Result<CarCategoryDto>.Ok(carCategoryDto);
        }

        public async Task<Result<IEnumerable<CarCategoryDto>>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges)
        {
            var carCategories = await _repoManager.CarCategory.GetCarCategoriesAsync(carCategoryParameters, trackChanges);
            var carCategoriesDto = _mapper.Map<IEnumerable<CarCategoryDto>>(carCategories);

            return Result<IEnumerable<CarCategoryDto>>.Ok(carCategoriesDto, carCategories.MetaData);
        }

        public async Task<Result> UpdateCarCategoryAsync(Guid id, CarCategoryDtoForUpdate carCategoryDtoForUpdate, bool trackChanges)
        {
            var checkIfExistResult = await GetByIdAndCheckIfExistAsync(id, trackChanges);

            if (!checkIfExistResult.IsSuccess)
                return Result.NotFound(checkIfExistResult.Errors!);
            var carCategoryEntity = checkIfExistResult.GetValue<CarCategory>();

            if (!carCategoryEntity.Category.Equals(carCategoryDtoForUpdate.Category))
            {
                var checkIfCarCategoryExistResult = await CheckIfCarCategoryExistByNameAsync(carCategoryDtoForUpdate.Category!);
                if (!checkIfCarCategoryExistResult.IsSuccess)
                    return checkIfCarCategoryExistResult;
            }

            _mapper.Map(carCategoryDtoForUpdate, carCategoryEntity);

            carCategoryEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}