using GarageManagementAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace GarageManagementAPI.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IWorkplaceRepository> _workplaceRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeInfoRepository> _employeeInfoRepository;
        private readonly Lazy<IBrandRepository> _brandoRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _workplaceRepository = new Lazy<IWorkplaceRepository>(() =>
            new WorkplaceRepository(repositoryContext));

            _userRepository = new Lazy<IUserRepository>(() =>
            new UserRepository(repositoryContext));

            _employeeInfoRepository = new Lazy<IEmployeeInfoRepository>(() =>
            new EmployeeInfoRepository(repositoryContext));
            _brandoRepository = new Lazy<IBrandRepository>(() =>
            new BrandRepository(repositoryContext));

        }

        public IWorkplaceRepository Workplace => _workplaceRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public IEmployeeInfoRepository EmployeeInfo => _employeeInfoRepository.Value;
        public IBrandRepository Brand => _brandoRepository.Value;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _repositoryContext.Database.BeginTransactionAsync();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _repositoryContext.Database.CreateExecutionStrategy();
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
