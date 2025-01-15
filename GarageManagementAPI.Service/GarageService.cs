using AutoMapper;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects;

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

        public IEnumerable<GarageDto> GetAllGarages(bool trackChanges)
        {
            var garages = _repository.Garage.GetAllGarages(trackChanges);
            var garagesDto = _mapper.Map<IEnumerable<GarageDto>>(garages);
            return garagesDto;
        }
    }
}
