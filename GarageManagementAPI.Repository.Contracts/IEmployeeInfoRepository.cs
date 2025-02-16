using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeInfoRepository : IRepositoryBase<EmployeeInfo>
    {
        public Task CreateEmployeeInfo(EmployeeInfo employeeInfo);

        public void UpdateEmployeeInfo(EmployeeInfo employeeInfo);

        public void DeleteEmployeeInfo(EmployeeInfo employeeInfo);
    }
}
