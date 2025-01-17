using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;
using GarageManagementAPI.Shared.Responses;
using GarageManagementAPI.Shared.Responses.GarageErrorResponse;

namespace GarageManagementAPI.Service
{
    public class GarageService : IGarageService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GarageService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        private async Task<ApiBaseResponse> GetGarageAndCheckIfItExists(Guid garageId, bool trackChanges)
        {
            var garage = await _repository.Garage.FindByIdAsync(garageId, trackChanges);
            if (garage is null)
                return new GarageNotFoundResponse(garageId);

            return new ApiOkResponse<Garage>(garage);
        }
        public async Task<ApiBaseResponse> CreateGarageAsync(GarageForCreationDto garageForCreationDto)
        {
            var garageEntity = _mapper.Map<Garage>(garageForCreationDto);

            _repository.Garage.Create(garageEntity);
            await _repository.SaveAsync();

            var garageToReturn = _mapper.Map<GarageDto>(garageEntity);

            return new ApiOkResponse<GarageDto>(garageToReturn); ;
        }

        public async Task<ApiBaseResponse> GetAllGaragesAsync(bool trackChanges)
        {
            var garages = await _repository.Garage.GetAllGaragesAsync(trackChanges);

            var garagesDto = _mapper.Map<IEnumerable<GarageDto>>(garages);

            return new ApiOkResponse<IEnumerable<GarageDto>>(garagesDto);

        }

        public async Task<ApiBaseResponse> GetGarageAsync(Guid garageId, bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.Success) return result;

            var garage = result.GetResult<Garage>();

            var garageDto = _mapper.Map<GarageDto>(garage);

            return new ApiOkResponse<GarageDto>(garageDto);
        }

        public async Task<ApiBaseResponse> UpdateGarageAsync(
            Guid garageId,
            GarageForUpdateDto garageForUpdateDto,
            bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.Success) return result;

            var garageEntity = result.GetResult<Garage>();

            _mapper.Map(garageForUpdateDto, garageEntity);
            await _repository.SaveAsync();

            return new ApiNoContentResponse();
        }

        public async Task<ApiBaseResponse> GetGarageForPatchAsync(Guid garageId, bool trackChanges)
        {
            var result = await GetGarageAndCheckIfItExists(garageId, trackChanges);

            if (!result.Success) return result;

            var garageEntity = result.GetResult<Garage>();

            var garageForPatch = _mapper.Map<GarageForUpdateDto>(garageEntity);

            return new ApiOkResponse<GarageForUpdateDto>(garageForPatch);
        }
    }
}
