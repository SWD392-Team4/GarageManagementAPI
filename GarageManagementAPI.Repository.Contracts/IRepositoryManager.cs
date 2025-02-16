namespace GarageManagementAPI.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IGarageRepository Garage { get; }

        IEmployeeRepository Employee { get; }

        void Save();
    }
}
