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
using GarageManagementAPI.Shared.ErrorsConstant.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Service
{
    public class CarPartService : ICarPartService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public CarPartService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }


        public async Task<Result<IEnumerable<ExpandoObject>>> GetCarPartsAsync(CarPartParameters CarPartParameters, bool trackChanges, string? include = null)
        {
            var carPartsWithMetadata = await _repoManager.CarPart.GetCarPartsAsync(CarPartParameters, trackChanges, include);

            var carPartsDto = _mapper.Map<IEnumerable<CarPartDto>>(carPartsWithMetadata);

            var carPartsShaped = _dataShaper.CarPart.ShapeData(carPartsDto, CarPartParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(carPartsShaped, carPartsWithMetadata.MetaData);
        }

        public async Task<Result<ExpandoObject>> GetCarPartAsync(Guid CarPartId, CarPartParameters CarPartParameters, bool trackChanges, string? include = null)
        {
            var CarPartResult = await GetAndCheckIfCarPartExist(CarPartId, trackChanges);

            if (!CarPartResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(CarPartResult.Errors!);

            var CarPartEntity = CarPartResult.GetValue<CarPart>();

            var CarPartsDto = _mapper.Map<CarPartDto>(CarPartEntity);

            var CarPartShaped = _dataShaper.CarPart.ShapeData(CarPartsDto, CarPartParameters.Fields);

            return Result<ExpandoObject>.Ok(CarPartShaped);
        }

        public async Task<Result<CarPartDto>> CreateCarPartAsync(CarPartDtoForCreation carPartDtoForCreation)
        {
            var check = await GetAndCheckIfCarPartExistByName(carPartDtoForCreation.PartName);
            if (check)
                return Result<CarPartDto>.BadRequest([CarPartErrors.GetCarPartNameAlreadyExistError(carPartDtoForCreation)]);

            var carPartEntity = _mapper.Map<CarPart>(carPartDtoForCreation);

            carPartEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            carPartEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            carPartEntity.Status = CarPartStatus.Inactive;

            await _repoManager.CarPart.CreateCarPartAsync(carPartEntity);
            await _repoManager.SaveAsync();

            var CarPartDtoToReturn = _mapper.Map<CarPartDto>(carPartEntity);

            return CarPartDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateCarPart(Guid carPartId, CarPartDtoForUpdate carPartDtoForUpdate, bool trackChanges)
        {
            var checkCarPartIsExistResult = await GetAndCheckIfCarPartExist(carPartId, trackChanges);
            var checkCarPartNameIsEXist = await GetAndCheckIfCarPartExistByName(carPartDtoForUpdate.PartName, carPartId);
            if (checkCarPartNameIsEXist)
                return Result<CarPartDto>.BadRequest([CarPartErrors.GetCarPartNameUpdateAlreadyExistError(carPartDtoForUpdate)]);
            if (!checkCarPartIsExistResult.IsSuccess)
                return Result<CarPartDto>.Failure(checkCarPartIsExistResult.StatusCode, checkCarPartIsExistResult.Errors!);
            var CarPartEntity = checkCarPartIsExistResult.GetValue<CarPart>();

            _mapper.Map(carPartDtoForUpdate, CarPartEntity);

            CarPartEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }
        public async Task<Result<CarPartDtoForUpdate>> GetCarPartForPartiallyUpdate(Guid carPartId, bool trackChanges)
        {
            var carPartResult = await GetAndCheckIfCarPartExist(carPartId, trackChanges);
            if (!carPartResult.IsSuccess)
                return Result<CarPartDtoForUpdate>.Failure(carPartResult.StatusCode, carPartResult.Errors!);

            var CarPartEntity = carPartResult.GetValue<CarPart>();

            var CarPartDtoForUpdate = _mapper.Map<CarPartDtoForUpdate>(CarPartEntity);

            return Result<CarPartDtoForUpdate>.Ok(CarPartDtoForUpdate);
        }

        private async Task<bool> GetAndCheckIfCarPartExistByName(string name, Guid? carPartId = null)
        {
            var CarPart = await _repoManager.CarPart.GetCarPartByIdAndNameAsync(name, carPartId, false);
            if (CarPart == null) return false;
            return true;
        }
        private async Task<Result<CarPart>> GetAndCheckIfCarPartExist(Guid carPartId, bool trackChanges)
        {
            var carPart = await _repoManager.CarPart.GetCarPartByIdAsync(carPartId, trackChanges);
            if (carPart == null)
                return carPart.NotFound(carPartId);

            return carPart.OkResult();
        }
    }
}
