using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.Responses;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IEmployeeService
    {
        ApiBaseResponse GetEmployees(Guid garageId, bool trackChanges);

        ApiBaseResponse GetEmployee(Guid garageId, Guid id, bool trackChanges);

        ApiBaseResponse CreateEmployeeForGarage(Guid garageId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges);
    }
}
