namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IWorkplaceRepository Workplace { get; }

        IUserRepository User { get; }

        IEmployeeInfoRepository EmployeeInfo { get; }

        Task SaveAsync();
    }
}
