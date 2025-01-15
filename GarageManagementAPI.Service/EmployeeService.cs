using AutoMapper;
using GarageManagementAPI.Entities.Exceptions.NotFound;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.Responses;
using GarageManagementAPI.Shared.Responses.GarageErrorResponse;

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

        public ApiBaseResponse CreateEmployeeForGarage(Guid garageId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            var garage = _repository.Garage.FindById(garageId, trackChanges);
            if (garage is null)
                return new GarageNotFoundResponse(garageId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.Create(garageId, employeeEntity);
            _repository.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return new ApiOkResponse<EmployeeDto>(employeeToReturn);
        }

        public ApiBaseResponse GetEmployee(Guid garageId, Guid id, bool trackChanges)
        {
            var company = _repository.Garage.FindById(garageId, trackChanges);
            if (company is null)
                throw new GarageNotFoundException(garageId);

            var employeeDb = _repository.Employee.GetEmployee(garageId, id, trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);

            return new ApiOkResponse<EmployeeDto>(employee);
        }

        public ApiBaseResponse GetEmployees(Guid garageId, bool trackChanges)
        {
            var company = _repository.Garage.FindById(garageId, trackChanges);
            if (company is null)
                throw new GarageNotFoundException(garageId);

            var employeesFromDb = _repository.Employee.GetEmployees(garageId, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            return new ApiOkResponse<IEnumerable<EmployeeDto>>(employeesDto);
        }


    }
}
