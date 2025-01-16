using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetEmployees(Guid garageId, bool trackChanges);

        Employee? FindById(Guid garageId, Guid employeeId, bool trackChanges);

        void Create(Guid garageId, Employee employee);
    }
}
