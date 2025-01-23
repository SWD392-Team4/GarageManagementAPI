using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Constant.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class EmployeeExtension
    {
        public static Result<Employee> ToOkResult(this Employee employee)
            => Result<Employee>.Ok(employee);

        public static Result<EmployeeDto> ToOkResult(this EmployeeDto employeeDto)
            => Result<EmployeeDto>.Ok(employeeDto);

        public static Result<EmployeeDto> ToCreatedResult(this EmployeeDto employeeDto)
            => Result<EmployeeDto>.Created(employeeDto);

        public static Result<EmployeeForUpdateDto> ToOkResult(this EmployeeForUpdateDto employeeForUpdateDto)
            => Result<EmployeeForUpdateDto>.Ok(employeeForUpdateDto);

        public static Result<Employee> NotFound(this Employee? employee, Guid employeeId)
            => Result<Employee>.NotFound([EmployeeErrors.GetEmployeeNotFoundError(employeeId)]);

    }
}
