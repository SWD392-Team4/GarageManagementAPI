using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<PagedList<Employee>> GetEmployeesAsync(
            Guid garageId,
            EmployeeParameters employeeParameters,
            bool trackChanges);

        Task<Employee?> FindByIdAsync(Guid garageId, Guid employeeId, bool trackChanges);

        void Create(Guid garageId, Employee employee);
    }
}
