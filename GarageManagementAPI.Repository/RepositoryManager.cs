using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IGarageRepository> _garageRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _garageRepository = new Lazy<IGarageRepository>(() =>
            new GarageRepository(repositoryContext));

            _employeeRepository = new Lazy<IEmployeeRepository>(() =>
            new EmployeeRepository(repositoryContext));
        }

        public IGarageRepository Garage => _garageRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
