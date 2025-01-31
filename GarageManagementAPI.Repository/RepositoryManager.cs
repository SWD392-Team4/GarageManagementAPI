using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IWorkplaceRepository> _workplaceRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _workplaceRepository = new Lazy<IWorkplaceRepository>(() =>
            new WorkplaceRepository(repositoryContext));

            _userRepository = new Lazy<IUserRepository>(() =>
            new UserRepository(repositoryContext));
        }

        public IWorkplaceRepository Workplace => _workplaceRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
