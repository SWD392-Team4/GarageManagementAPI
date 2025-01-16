using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid garageId, bool trackChanges)
            => FindByCondition(e => e.GarageId.Equals(garageId), trackChanges)
            .OrderBy(e => e.Name).ToList();

        public Employee? FindById(Guid garageId, Guid employeeId, bool trackChanges)
            => FindByCondition(e => e.GarageId.Equals(garageId) && e.Id.Equals(employeeId), trackChanges)
            .SingleOrDefault();

        public void Create(Guid garageId, Employee employee)
        {
            employee.GarageId = garageId;
            Create(employee);
        }
    }
}
