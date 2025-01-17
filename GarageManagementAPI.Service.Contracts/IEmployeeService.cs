using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IEmployeeService
    {
        Task<ApiBaseResponse> GetEmployeesAsync(
            Guid garageId,
            EmployeeParameters employeeParameters,
            bool trackChanges);

        Task<ApiBaseResponse> GetEmployeeAsync(
            Guid garageId,
            Guid employeeId,
            bool trackChanges);

        Task<ApiBaseResponse> CreateEmployeeForGarageAsync(
            Guid garageId,
            EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges);

        Task<ApiBaseResponse> UpdateEmployeeForGarageAsync(
            Guid garageId,
            Guid employeeId,
            EmployeeForUpdateDto employeeForUpdateDto,
            bool garageTrackChanges,
            bool employeeTrackChanges);

        Task<ApiBaseResponse> GetEmployeeForPatchAsync(
            Guid garageId,
            Guid employeeId,
            bool trackChanges);

    }
}
