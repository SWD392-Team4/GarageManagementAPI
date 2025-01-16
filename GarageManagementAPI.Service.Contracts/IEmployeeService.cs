using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IEmployeeService
    {
        ApiBaseResponse GetEmployees(
            Guid garageId,
            bool trackChanges);

        ApiBaseResponse GetEmployee(
            Guid garageId,
            Guid employeeId,
            bool trackChanges);

        ApiBaseResponse CreateEmployeeForGarage(
            Guid garageId,
            EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges);

        ApiBaseResponse UpdateEmployeeForGarage(
            Guid garageId,
            Guid employeeId,
            EmployeeForUpdateDto employeeForUpdateDto,
            bool garageTrackChanges,
            bool employeeTrackChanges);

        ApiBaseResponse UpdateEmployeeForGarage(
            Guid garageId,
            Guid employeeId,
            JsonPatchDocument<EmployeeForUpdateDto> employeePatchDoc,
            bool garageTrackChanges,
            bool employeeTrackChanges);

    }
}
