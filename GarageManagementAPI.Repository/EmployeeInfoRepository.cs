using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class EmployeeInfoRepository : RepositoryBase<EmployeeInfo>, IEmployeeInfoRepository
    {
        public EmployeeInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            await base.CreateAsync(employeeInfo);

        }

        public void DeleteEmployeeInfo(EmployeeInfo employeeInfo)
        {
            base.Delete(employeeInfo);
        }

        public void UpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            base.Update(employeeInfo);
        }

    }
}
