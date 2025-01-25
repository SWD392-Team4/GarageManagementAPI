using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<PagedList<Employee>> GetEmployeesAsync(
            EmployeeParameters employeeParameters,
            bool trackChanges);
    }
}
