using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using GarageManagementAPI.Shared.Extension;
using System.Dynamic;

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

        public async Task<Result<ExpandoObject>> CreateCarCategoryAsync(CarCategoryDtoForCreate carCategoryDtoForCreate, string? fields = null)
        {
            var checkIfCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(carCategoryDtoForCreate.Category!, false);

            if (checkIfCarCategoryExist is not null)
                return Result<ExpandoObject>.Conflict(CarCategoryErrors.GetCarCategoryAlreadyExist(carCategoryDtoForCreate.Category!));

            var carCategoryEntity = _mapper.Map<CarCategory>(carCategoryDtoForCreate);

            await _repoManager.CarCategory.CreateAsync(carCategoryEntity);
            await _repoManager.SaveAsync();

            var carCategoryDto = _mapper.Map<CarCategoryDto>(carCategoryEntity);

            var categoryDtoShaped = _dataShaper.CarCategory.ShapeData(carCategoryDto, fields);

            return Result<ExpandoObject>.Ok(categoryDtoShaped);
        }

        public async Task<Result<ExpandoObject>> GetCarCategoryAsync(Guid id, bool trackChanges, string? fields = null)
        {
            var carCategory = await _repoManager.CarCategory.GetCarCategoryAsync(id, trackChanges);

            if (carCategory is null)
                return Result<ExpandoObject>.NotFound(CarCategoryErrors.GetCarCategoryNotFoundError(id));

            var carCategoryDto = _mapper.Map<CarCategoryDto>(carCategory);

            var categoryDtoShaped = _dataShaper.CarCategory.ShapeData(carCategoryDto, fields);

            return Result<ExpandoObject>.Ok(categoryDtoShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges)
        {
            var carCategories = await _repoManager.CarCategory.GetCarCategoriesAsync(carCategoryParameters, trackChanges);

            var carCategoriesDto = _mapper.Map<IEnumerable<CarCategoryDto>>(carCategories);

            var carCategoriesDtoShaped = _dataShaper.CarCategory.ShapeData(carCategoriesDto, carCategoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(carCategoriesDtoShaped, carCategories.MetaData);
        }

        public async Task<Result> UpdateCarCategoryAsync(Guid id, CarCategoryDtoForUpdate carCategoryDtoForUpdate, bool trackChanges)
        {

            var carCategoryEntity = await _repoManager.CarCategory.GetCarCategoryAsync(id, trackChanges);

            if (carCategoryEntity is null)
                return Result<CarCategory>.NotFound([CarCategoryErrors.GetCarCategoryNotFoundError(id)]);

            if (!carCategoryEntity.Category.Equals(carCategoryDtoForUpdate.Category))
            {
                var checkIfCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(carCategoryDtoForUpdate.Category!, false);

                if (checkIfCarCategoryExist is not null)
                    return Result<CarCategoryDto>.Conflict(CarCategoryErrors.GetCarCategoryAlreadyExist(carCategoryDtoForUpdate.Category!));
            }

            _mapper.Map(carCategoryDtoForUpdate, carCategoryEntity);

            carCategoryEntity.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}