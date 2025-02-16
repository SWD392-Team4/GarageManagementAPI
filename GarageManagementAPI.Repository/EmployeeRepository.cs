using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

    }
}
