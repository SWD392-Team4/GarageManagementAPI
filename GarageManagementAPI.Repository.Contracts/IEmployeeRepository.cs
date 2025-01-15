using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetEmployees(Guid garageId, bool trackChanges);

        Employee? GetEmployee(Guid garageId, Guid id, bool trackChanges);

        void Create(Guid garageId, Employee employee);
    }
}
