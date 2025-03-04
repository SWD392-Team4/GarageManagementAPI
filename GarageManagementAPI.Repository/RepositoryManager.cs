using Microsoft.EntityFrameworkCore.Storage;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<IServiceRepository> _serviceRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICarPartRepository> _carPartRepository;
        private readonly Lazy<ICarModelRepository> _carModelRepository;
        private readonly Lazy<ISupplierRepository> _supplierRepository;
        private readonly Lazy<IWorkplaceRepository> _workplaceRepository;
        private readonly Lazy<ICarCategoryRepository> _carCategoryRepository;
        private readonly Lazy<IServiceImageRepository> _serviceImageRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;
        private readonly Lazy<IEmployeeInfoRepository> _employeeInfoRepository;
        private readonly Lazy<IGoodsReceivedRepository> _goodsReceivedtRepository;
        private readonly Lazy<IProductHistoryRepository> _productHistoryRepository;
        private readonly Lazy<IServiceHistoryRepository> _serviceHistoryRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<ICarPartCategoryRepository> _carPartCategoryRepository;
        private readonly Lazy<IServiceFeedBackRepository> _serviceFeedBackRepository;
        private readonly Lazy<ISupplierContactRepository> _supplierContactRepository;
        private readonly Lazy<IGoodsReceivedDetailRepository> _goodsReceivedDetailRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _carPartRepository = new Lazy<ICarPartRepository>(() => new CarPartRepository(repositoryContext));
            _serviceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(repositoryContext));
            _carModelRepository = new Lazy<ICarModelRepository>(() => new CarModelRepository(repositoryContext));
            _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(repositoryContext));
            _workplaceRepository = new Lazy<IWorkplaceRepository>(() => new WorkplaceRepository(repositoryContext));
            _carCategoryRepository = new Lazy<ICarCategoryRepository>(() => new CarCategoryRepository(repositoryContext));
            _serviceImageRepository = new Lazy<IServiceImageRepository>(() => new ServiceImageRepository(repositoryContext));
            _productImageRepository = new Lazy<IProductImageRepository>(() => new ProductImageRepository(repositoryContext));
            _employeeInfoRepository = new Lazy<IEmployeeInfoRepository>(() => new EmployeeInfoRepository(repositoryContext));
            _goodsReceivedtRepository = new Lazy<IGoodsReceivedRepository>(() => new GoodsReceivedRepository(repositoryContext));
            _productHistoryRepository = new Lazy<IProductHistoryRepository>(() => new ProductHistoryRepository(repositoryContext));
            _serviceHistoryRepository = new Lazy<IServiceHistoryRepository>(() => new ServiceHistoryRepository(repositoryContext));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));
            _carPartCategoryRepository = new Lazy<ICarPartCategoryRepository>(() => new CarPartCategoryRepository(repositoryContext));
            _serviceFeedBackRepository = new Lazy<IServiceFeedBackRepository>(() => new ServiceFeedBackRepository(repositoryContext));
            _supplierContactRepository = new Lazy<ISupplierContactRepository>(() => new SupplierContactRepository(repositoryContext));
            _goodsReceivedDetailRepository = new Lazy<IGoodsReceivedDetailRepository>(() => new GoodsReceivedDetailRepository(repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IBrandRepository Brand => _brandRepository.Value;
        public IServiceRepository Service => _serviceRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public ICarPartRepository CarPart => _carPartRepository.Value;
        public ICarModelRepository CarModel => _carModelRepository.Value;
        public ISupplierRepository Supplier => _supplierRepository.Value;
        public IWorkplaceRepository Workplace => _workplaceRepository.Value;
        public ICarCategoryRepository CarCategory => _carCategoryRepository.Value;
        public IServiceImageRepository ServiceImage => _serviceImageRepository.Value;
        public IProductImageRepository ProductImage => _productImageRepository.Value;
        public IEmployeeInfoRepository EmployeeInfo => _employeeInfoRepository.Value;
        public IGoodsReceivedRepository GoodsReceived => _goodsReceivedtRepository.Value;
        public IProductHistoryRepository ProductHistory => _productHistoryRepository.Value;
        public IServiceHistoryRepository ServiceHistory => _serviceHistoryRepository.Value;
        public IServiceFeedBackRepository ServiceFeeback => _serviceFeedBackRepository.Value;
        public IProductCategoryRepository ProductCategory => _productCategoryRepository.Value;
        public ICarPartCategoryRepository CarPartCategory => _carPartCategoryRepository.Value;
        public ISupplierContactRepository SupplierContact => _supplierContactRepository.Value;
        public IGoodsReceivedDetailRepository GoodsReceivedDetail => _goodsReceivedDetailRepository.Value;


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
