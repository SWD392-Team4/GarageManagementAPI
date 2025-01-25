using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enum;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(
            EmployeeParameters employeeParameters,
            bool trackChanges)
        {
            var employeeQuery = employeeParameters.GarageId != null ?
                FindByCondition(e => e.GarageId.Equals(employeeParameters.GarageId), trackChanges) : FindAll(trackChanges);

            var employees = await employeeQuery
            .Search(employeeParameters.SearchTerm)
            .Sort(employeeParameters.OrderBy)
            .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
            .Take(employeeParameters.PageSize)
            .Includes(employeeParameters.Include)
            .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Employee>(
                employees,
                count,
                employeeParameters.PageNumber,
                employeeParameters.PageSize);
        }

        public override void Create(Employee entity)
        {
            entity.Status = SystemStatus.Inactive;
            base.Create(entity);
        }
    }
}
