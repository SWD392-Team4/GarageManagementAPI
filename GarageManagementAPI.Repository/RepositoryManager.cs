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
        private readonly Lazy<IAppointmentRepository> _appointmentRepository;
        private readonly Lazy<IPackageRepository> _packageRepository;
        private readonly Lazy<IPackageConditionRepository> _packageConditionRepository;
        private readonly Lazy<IPackageFeedBackRepository> _packageFeedBackRepository;
        private readonly Lazy<IPackageHistoryRepository> _packageHistoryRepository;
        private readonly Lazy<IPackageImageRepository> _packageImageRepository;
        private readonly Lazy<IPackageUsageRepository> _packageUsageRepository;
        private readonly Lazy<IPackageUsageDetailRepository> _packageUsageDetailRepository;
        private readonly Lazy<IPackageDetailRepository> _packageDetailRepository;

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
            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
            _packageRepository = new Lazy<IPackageRepository>(() => new PackageRepository(repositoryContext));
            _packageConditionRepository = new Lazy<IPackageConditionRepository>(() => new PackageConditionRepository(repositoryContext));
            _packageFeedBackRepository = new Lazy<IPackageFeedBackRepository>(() => new PackageFeedBackRepository(repositoryContext));
            _packageHistoryRepository = new Lazy<IPackageHistoryRepository>(() => new PackageHistoryRepository(repositoryContext));
            _packageImageRepository = new Lazy<IPackageImageRepository>(() => new PackageImageRepository(repositoryContext));
            _packageUsageRepository = new Lazy<IPackageUsageRepository>(() => new PackageUsageRepository(repositoryContext));
            _packageUsageDetailRepository = new Lazy<IPackageUsageDetailRepository>(() => new PackageUsageDetailRepository(repositoryContext));
            _packageDetailRepository = new Lazy<IPackageDetailRepository>(() => new PackageDetailRepository(repositoryContext));
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
        public IAppointmentRepository Appointment => _appointmentRepository.Value;
        public IPackageRepository Package => _packageRepository.Value;
        public IPackageConditionRepository PackageCondition => _packageConditionRepository.Value;
        public IPackageFeedBackRepository PackageFeedBack => _packageFeedBackRepository.Value;
        public IPackageHistoryRepository PackageHistory => _packageHistoryRepository.Value;
        public IPackageImageRepository PackageImage => _packageImageRepository.Value;
        public IPackageUsageRepository PackageUsage => _packageUsageRepository.Value;
        public IPackageUsageDetailRepository PackageUsageDetail => _packageUsageDetailRepository.Value;
        public IPackageDetailRepository PackageDetail => _packageDetailRepository.Value;

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
