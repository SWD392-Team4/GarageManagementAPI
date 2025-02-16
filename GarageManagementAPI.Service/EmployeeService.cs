using AutoMapper;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;

namespace GarageManagementAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
