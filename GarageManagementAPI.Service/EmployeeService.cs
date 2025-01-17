using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Responses;
using GarageManagementAPI.Shared.Responses.EmployeeErrorResponse;
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

        private async Task<ApiBaseResponse> CheckIfGarageExist(Guid garageId, bool trackChanges)
        {
            var garage = await _repository.Garage.FindByIdAsync(garageId, trackChanges);
            if (garage is null)
                return new GarageNotFoundResponse(garageId);

            return new ApiNoContentResponse();
        }

        private async Task<ApiBaseResponse> GetEmployeeForGarageAndCheckIfExists(Guid garageId, Guid employeeId, bool trackChanges)
        {
            var employeeEntity = await _repository.Employee.FindByIdAsync(garageId, employeeId, trackChanges);
            if (employeeEntity is null)
                return new EmployeeNotFoundResponse(employeeId);

            return new ApiOkResponse<Employee>(employeeEntity);
        }

        public async Task<ApiBaseResponse> CreateEmployeeForGarageAsync(
            Guid garageId,
            EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges)
        {
            var result = await CheckIfGarageExist(garageId, trackChanges);

            if (!result.Success) return result;

            var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.Create(garageId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return new ApiOkResponse<EmployeeDto>(employeeToReturn);
        }

        public async Task<ApiBaseResponse> GetEmployeeAsync(
            Guid garageId,
            Guid employeeId,
            bool trackChanges)
        {
            var result = await CheckIfGarageExist(garageId, trackChanges);

            if (!result.Success) return result;

            result = await GetEmployeeForGarageAndCheckIfExists(garageId, employeeId, trackChanges);

            if (!result.Success) return result;

            var employeeEntity = result.GetResult<Employee>();

            var employee = _mapper.Map<EmployeeDto>(employeeEntity);

            return new ApiOkResponse<EmployeeDto>(employee);
        }

        public async Task<ApiBaseResponse> GetEmployeesAsync(
            Guid garageId,
            EmployeeParameters employeeParameters,
            bool trackChanges)
        {
            var result = await CheckIfGarageExist(garageId, trackChanges);

            if (!result.Success) return result;

            var employeesWithMetaData = await _repository.Employee
                .GetEmployeesAsync(
                garageId: garageId,
                employeeParameters: employeeParameters,
                trackChanges: trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            var pageInfo = new PageInfo(employeesDto, employeesWithMetaData.MetaData);

            return new ApiOkResponse<PageInfo>(pageInfo);
        }

        public async Task<ApiBaseResponse> UpdateEmployeeForGarageAsync(
            Guid garageId,
            Guid employeeId,
            EmployeeForUpdateDto employeeForUpdate,
            bool garageTrackChanges,
            bool employeeTrackChanges)
        {
            var result = await CheckIfGarageExist(garageId, garageTrackChanges);

            if (!result.Success) return result;

            result = await GetEmployeeForGarageAndCheckIfExists(garageId, employeeId, employeeTrackChanges);

            if (!result.Success) return result;

            var employeeEntity = result.GetResult<Employee>();

            _mapper.Map(employeeForUpdate, employeeEntity);
            await _repository.SaveAsync();

            return new ApiNoContentResponse();
        }

        public async Task<ApiBaseResponse> GetEmployeeForPatchAsync(Guid garageId, Guid employeeId, bool trackChanges)
        {
            var result = await CheckIfGarageExist(garageId, trackChanges);

            if (!result.Success) return result;

            result = await GetEmployeeForGarageAndCheckIfExists(garageId, employeeId, trackChanges);

            if (!result.Success) return result;

            var employeeEntity = result.GetResult<Employee>();

            var employeeForPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return new ApiOkResponse<EmployeeForUpdateDto>(employeeForPatch);
        }
    }
}
