using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
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

        public ApiBaseResponse CreateGarage(GarageForCreationDto garageForCreationDto)
        {
            var garageEntity = _mapper.Map<Garage>(garageForCreationDto);

            _repository.Garage.Create(garageEntity);
            _repository.Save();

            var garageToReturn = _mapper.Map<GarageDto>(garageEntity);

            return new ApiOkResponse<GarageDto>(garageToReturn); ;
        }

        public ApiBaseResponse GetAllGarages(bool trackChanges)
        {
            var garages = _repository.Garage.GetAllGarages(trackChanges);

            var garagesDto = _mapper.Map<IEnumerable<GarageDto>>(garages);

            return new ApiOkResponse<IEnumerable<GarageDto>>(garagesDto);

        }

        public ApiBaseResponse GetGarage(Guid id, bool trackChanges)
        {
            var garage = _repository.Garage.FindById(id, trackChanges);
            if (garage is null)
                return new GarageNotFoundResponse(id);

            var garageDto = _mapper.Map<GarageDto>(garage);

            return new ApiOkResponse<GarageDto>(garageDto);
        }
    }
}
