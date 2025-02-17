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
        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductHistoryRepository> _productHistoryRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _workplaceRepository = new Lazy<IWorkplaceRepository>(() =>
            new WorkplaceRepository(repositoryContext));

            _userRepository = new Lazy<IUserRepository>(() =>
            new UserRepository(repositoryContext));

            _employeeInfoRepository = new Lazy<IEmployeeInfoRepository>(() =>
            new EmployeeInfoRepository(repositoryContext));

            _brandRepository = new Lazy<IBrandRepository>(() =>
            new BrandRepository(repositoryContext));

            _productRepository = new Lazy<IProductRepository>(() =>
            new ProductRepository(repositoryContext));

            _productHistoryRepository = new Lazy<IProductHistoryRepository>(() => new ProductHistoryRepository(repositoryContext));

            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));

            _productImageRepository = new Lazy<IProductImageRepository>(() => new ProductImageRepository(repositoryContext));

        }

        public IWorkplaceRepository Workplace => _workplaceRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IEmployeeInfoRepository EmployeeInfo => _employeeInfoRepository.Value;
        public IBrandRepository Brand => _brandRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public IProductHistoryRepository ProductHistory => _productHistoryRepository.Value;
        public IProductCategoryRepository ProductCategory => _productCategoryRepository.Value;
        public IProductImageRepository ProductImage => _productImageRepository.Value;

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
