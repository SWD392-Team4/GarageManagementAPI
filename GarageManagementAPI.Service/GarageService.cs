using AutoMapper;
using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class GarageService : IGarageService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public GarageService(
            IRepositoryManager repository,
            IMapper mapper,
            IDataShaperManager dataShaperManager)
        {
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaperManager;
        }
        private async Task<Result> GetGarageAndCheckIfItExists(Guid garageId, bool trackChanges)
        {
            var garage = await _repository.Garage.FindByIdAsync(garageId, trackChanges);
            if (garage is null)
                return garage.GarageNotFound(garageId);

            return garage.ToOkResult();
        }
        public async Task<Result> CreateGarageAsync(GarageForCreationDto garageForCreationDto)
        {
            var garageEntity = _mapper.Map<Garage>(garageForCreationDto);

            _repository.Garage.Create(garageEntity);
            await _repository.SaveAsync();

            var garageToReturn = _mapper.Map<GarageDto>(garageEntity);

            return garageToReturn.ToCreatedResult();
        }

        public async Task<Result> GetAllGaragesAsync(
            GarageParameters garageParameters,
            bool trackChanges)
        {
            var garagesWithMetaData = await _repository.Garage.GetAllGaragesAsync(garageParameters, trackChanges);

            var garagesDto = _mapper.Map<IEnumerable<GarageDtoWithRelation>>(garagesWithMetaData);

            var shapedDto = _dataShaper.GarageShaper.ShapeData(garagesDto, garageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(shapedDto, garagesWithMetaData.MetaData);

        }

        public async Task<Result> GetGarageAsync(
            Guid garageId,
            GarageParameters garageParameters,
            bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.IsSuccess)
                return result;

            var garage = result.GetValue<Garage>();

            var garageDto = _mapper.Map<GarageDtoWithRelation>(garage);

            var shapedDto = _dataShaper.GarageShaper.ShapeData(garageDto, garageParameters.Fields);

            return Result<ExpandoObject>.Ok(shapedDto);
        }

        public async Task<Result> UpdateGarageAsync(
            Guid garageId,
            GarageForUpdateDto garageForUpdateDto,
            bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.IsSuccess)
                return result;

            var garageEntity = result.GetValue<Garage>();

            _mapper.Map(garageForUpdateDto, garageEntity);

            await _repository.SaveAsync();

            return Result.NoContent();
        }

        public async Task<Result> GetGarageForPatchAsync(Guid garageId, bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.IsSuccess)
                return result;

            var garageEntity = result.GetValue<Garage>();

            var garageForPatch = _mapper.Map<GarageForUpdateDto>(garageEntity);

            return garageForPatch.ToOkResult();
        }
    }
}
