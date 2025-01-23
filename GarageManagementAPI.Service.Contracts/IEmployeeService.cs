using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IEmployeeService
    {
        Task<Result> GetEmployeeAsync(
            Guid employeeId,
            EmployeeParameters employeeParameters,
            bool trackChanges);

        Task<Result> GetEmployeesAsync(
            EmployeeParameters employeeParameters,
            bool trackChanges);

        Task<Result> CreateEmployeeAsync(
            EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges);

        Task<Result> UpdateEmployeeAsync(
            Guid employeeId,
            EmployeeForUpdateDto employeeForUpdateDto,
            bool employeeTrackChanges);

        Task<Result> GetEmployeeForPatchAsync(
            Guid employeeId,
            bool trackChanges);

    }
}
