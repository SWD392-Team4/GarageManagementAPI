using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace GarageManagementAPI.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(
            Guid garageId,
            EmployeeParameters employeeParameters,
            bool trackChanges)
        {
            var employees = await FindByCondition(e =>
            e.GarageId.Equals(garageId),
                trackChanges)
            .Search(employeeParameters.SearchTerm)
            .Sort(employeeParameters.OrderBy)
            .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
            .Take(employeeParameters.PageSize)
            .Includes(employeeParameters.Include)
            .ToListAsync();

            var count = await FindByCondition(e => e.GarageId.Equals(garageId), trackChanges).CountAsync();


            return new PagedList<Employee>(
                employees,
                count,
                employeeParameters.PageNumber,
                employeeParameters.PageSize);
        }

        public async Task<Employee?> FindByIdAsync(Guid garageId, Guid employeeId, bool trackChanges)
            => await FindByCondition(e =>
            e.GarageId.Equals(garageId) && e.Id.Equals(employeeId),
                trackChanges)
            .SingleOrDefaultAsync();

        public void Create(Guid garageId, Employee employee)
        {
            employee.GarageId = garageId;
            Create(employee);
        }
    }
}
