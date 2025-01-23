using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public EmployeeService(
            IRepositoryManager repository,
            IMapper mapper,
            IDataShaperManager dataShaperManager)
        {
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaperManager;
        }

        private async Task<Result> CheckIfGarageExist(
            Guid garageId,
            bool trackChanges)
        {
            var garage = await _repository.Garage.FindByIdAsync(garageId, trackChanges);
            if (garage is null)
                return garage.GarageNotFound(garageId);

            return Result.NoContent();
        }

        private async Task<Result> CheckIfEmployeeExist(
            Guid employeeId,
            bool trackChanges)
        {
            var employeeEntity = await _repository.Employee.FindByIdAsync(employeeId, trackChanges);
            if (employeeEntity is null)
                return employeeEntity.NotFound(employeeId);

            return employeeEntity.ToOkResult();
        }

        private async Task<Result> CheckIfGarageAndEmployeeExist(
            Guid garageId,
            Guid employeeId,
            bool garageTrackChanges,
            bool employeeTrackChanges)
        {
            var garageResult = await CheckIfGarageExist(garageId, garageTrackChanges);
            if (!garageResult.IsSuccess) return garageResult;

            var employeeResult = await CheckIfEmployeeExist(employeeId, employeeTrackChanges);
            if (!employeeResult.IsSuccess) return employeeResult;

            return employeeResult;
        }

        public async Task<Result> GetEmployeeAsync(
            Guid employeeId,
            EmployeeParameters employeeParameters,
            bool trackChanges)
        {
            var result = await CheckIfEmployeeExist(employeeId, trackChanges);
            if (!result.IsSuccess)
                return result;

            var employeeEntity = result.GetValue<Employee>();

            var employeeDto = _mapper.Map<EmployeeDtoWithRelation>(employeeEntity);

            var shapedEmployee = _dataShaper.EmployeeShaper.ShapeData(employeeDto, employeeParameters.Fields);

            return Result<ExpandoObject>.Ok(shapedEmployee);
        }

        public async Task<Result> GetEmployeesAsync(
            EmployeeParameters employeeParameters,
            bool trackChanges)
        {
            var employeesWithMetaData = await _repository.Employee
                .GetEmployeesAsync(
                employeeParameters: employeeParameters,
                trackChanges: trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDtoWithRelation>>(employeesWithMetaData);

            var shapedDto = _dataShaper
                .EmployeeShaper.ShapeData(employeesDto, employeeParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(shapedDto, employeesWithMetaData.MetaData);
        }

        public async Task<Result> GetEmployeeForPatchAsync(
            Guid employeeId,
            bool trackChanges)
        {
            var result = await CheckIfEmployeeExist(employeeId, trackChanges);
            if (!result.IsSuccess)
                return result;

            if (!result.IsSuccess) return result;

            var employeeEntity = result.GetValue<Employee>();

            var employeeForPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return employeeForPatch.ToOkResult();
        }

        public async Task<Result> CreateEmployeeAsync(
            EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges)
        {
            var garageResult = await CheckIfGarageExist(employeeForCreationDto.GarageId, trackChanges);

            if (!garageResult.IsSuccess)
                return garageResult;

            var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.Create(employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDtoWithRelation>(employeeEntity);

            return employeeToReturn.ToCreatedResult();
        }

        public async Task<Result> UpdateEmployeeAsync(
            Guid employeeId,
            EmployeeForUpdateDto employeeForUpdate,
            bool employeeTrackChanges)
        {
            var result = await CheckIfGarageAndEmployeeExist(
               garageId: employeeForUpdate.GarageId,
               employeeId: employeeId,
               garageTrackChanges: false,
               employeeTrackChanges: employeeTrackChanges);

            if (!result.IsSuccess) return result;

            var employeeEntity = result.GetValue<Employee>();

            _mapper.Map(employeeForUpdate, employeeEntity);
            await _repository.SaveAsync();

            return Result.NoContent();
        }




    }
}
