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
        private readonly Lazy<IInvoiceRepository> _invoiceRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICarPartRepository> _carPartRepository;
        private readonly Lazy<IPackageRepository> _packageRepository;
        private readonly Lazy<ICarModelRepository> _carModelRepository;
        private readonly Lazy<ISupplierRepository> _supplierRepository;
        private readonly Lazy<IWorkplaceRepository> _workplaceRepository;
        private readonly Lazy<IAppointmentRepository> _appointmentRepository;
        private readonly Lazy<ICarCategoryRepository> _carCategoryRepository;
        private readonly Lazy<IGoodsIssuedRepository> _goodsIssuedRepository;
        private readonly Lazy<IServiceImageRepository> _serviceImageRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;
        private readonly Lazy<IEmployeeInfoRepository> _employeeInfoRepository;
        private readonly Lazy<IPackageImageRepository> _packageImageRepository;
        private readonly Lazy<IPackageUsageRepository> _packageUsageRepository;
        private readonly Lazy<IPackageDetailRepository> _packageDetailRepository;
        private readonly Lazy<IGoodsReceivedRepository> _goodsReceivedtRepository;
        private readonly Lazy<IProductHistoryRepository> _productHistoryRepository;
        private readonly Lazy<IServiceHistoryRepository> _serviceHistoryRepository;
        private readonly Lazy<IPackageHistoryRepository> _packageHistoryRepository;
        private readonly Lazy<ISupplierContactRepository> _supplierContactRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<ICarPartCategoryRepository> _carPartCategoryRepository;
        private readonly Lazy<IServiceFeedBackRepository> _serviceFeedBackRepository;
        private readonly Lazy<IPackageFeedBackRepository> _packageFeedBackRepository;
        private readonly Lazy<IProductAtGarageRepository> _productAtGarageRepository;
        private readonly Lazy<IPackageConditionRepository> _packageConditionRepository;
        private readonly Lazy<IGoodsTransactionRepository> _goodsTransactionRepository;
        private readonly Lazy<IGoodsIssuedDetailRepository> _goodsIssuedDetaiRepository;
        private readonly Lazy<IAppointmentPerDayRepository> _appointmentPerDayRepository;
        private readonly Lazy<IAppointmentDetailRepository> _appointmentDetailRepository;
        private readonly Lazy<IInvoiceSellProductRepository> invoiceSellProductRepository;
        private readonly Lazy<IProductAtWarehouseRepository> _productAtWarehouseRepository;
        private readonly Lazy<IPackageUsageDetailRepository> _packageUsageDetailRepository;
        private readonly Lazy<IInvoiceSellProductRepository> _invoiceSellProductRepository;
        private readonly Lazy<IGoodsReceivedDetailRepository> _goodsReceivedDetailRepository;
        private readonly Lazy<IAppointmentDetailPackageRepository> _appointmentDetailPackageRepository;
        private readonly Lazy<IAppointmentReplacementPartRepository> _appointmentReplacementPartRepository;
        private readonly Lazy<IInvoiceSellProduct_ProductAtGarageRepository> _invoiceSellProduct_ProductAtGarageRepository;
        private readonly Lazy<IGoodsIssuedDetailProductAtWarehouseRepository> _goodsIssuedDetailProductAtWarehouseRepository;

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
            _goodsIssuedRepository = new Lazy<IGoodsIssuedRepository>(() => new GoodsIssuedRepository(repositoryContext));
            _carCategoryRepository = new Lazy<ICarCategoryRepository>(() => new CarCategoryRepository(repositoryContext));
            _serviceImageRepository = new Lazy<IServiceImageRepository>(() => new ServiceImageRepository(repositoryContext));
            _productImageRepository = new Lazy<IProductImageRepository>(() => new ProductImageRepository(repositoryContext));
            _employeeInfoRepository = new Lazy<IEmployeeInfoRepository>(() => new EmployeeInfoRepository(repositoryContext));
            _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(repositoryContext));
            _invoiceSellProductRepository = new Lazy<IInvoiceSellProductRepository>(() => new InvoiceSellProductRepository(repositoryContext));
            _goodsReceivedtRepository = new Lazy<IGoodsReceivedRepository>(() => new GoodsReceivedRepository(repositoryContext));
            _productHistoryRepository = new Lazy<IProductHistoryRepository>(() => new ProductHistoryRepository(repositoryContext));
            _serviceHistoryRepository = new Lazy<IServiceHistoryRepository>(() => new ServiceHistoryRepository(repositoryContext));
            _productAtGarageRepository = new Lazy<IProductAtGarageRepository>(() => new ProductAtGarageRepostitory(repositoryContext));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));
            _carPartCategoryRepository = new Lazy<ICarPartCategoryRepository>(() => new CarPartCategoryRepository(repositoryContext));
            _serviceFeedBackRepository = new Lazy<IServiceFeedBackRepository>(() => new ServiceFeedBackRepository(repositoryContext));
            _supplierContactRepository = new Lazy<ISupplierContactRepository>(() => new SupplierContactRepository(repositoryContext));
            _goodsTransactionRepository = new Lazy<IGoodsTransactionRepository>(() => new GoodsTransactionRepository(repositoryContext));
            _invoiceSellProduct_ProductAtGarageRepository = new Lazy<IInvoiceSellProduct_ProductAtGarageRepository>(() => new InvoiceSellProduct_ProductAtGarageRepository(repositoryContext));
            _goodsIssuedDetaiRepository = new Lazy<IGoodsIssuedDetailRepository>(() => new GoodsIssuedDetailRepository(repositoryContext));
            _invoiceSellProductRepository = new Lazy<IInvoiceSellProductRepository>(() => new InvoiceSellProductRepository(repositoryContext));
            _goodsReceivedDetailRepository = new Lazy<IGoodsReceivedDetailRepository>(() => new GoodsReceivedDetailRepository(repositoryContext));
            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
            _appointmentPerDayRepository = new Lazy<IAppointmentPerDayRepository>(() => new AppointmentPerDayRepository(repositoryContext));
            _appointmentDetailRepository = new Lazy<IAppointmentDetailRepository>(() => new AppointmentDetailRepository(repositoryContext));
            _appointmentDetailPackageRepository = new Lazy<IAppointmentDetailPackageRepository>(() => new AppointmentDetailPackageRepository(repositoryContext));
            _appointmentReplacementPartRepository = new Lazy<IAppointmentReplacementPartRepository>(() => new AppointmentReplacementPartRepository(repositoryContext));
            _packageRepository = new Lazy<IPackageRepository>(() => new PackageRepository(repositoryContext));
            _packageConditionRepository = new Lazy<IPackageConditionRepository>(() => new PackageConditionRepository(repositoryContext));
            _packageFeedBackRepository = new Lazy<IPackageFeedBackRepository>(() => new PackageFeedBackRepository(repositoryContext));
            _packageHistoryRepository = new Lazy<IPackageHistoryRepository>(() => new PackageHistoryRepository(repositoryContext));
            _packageImageRepository = new Lazy<IPackageImageRepository>(() => new PackageImageRepository(repositoryContext));
            _packageUsageRepository = new Lazy<IPackageUsageRepository>(() => new PackageUsageRepository(repositoryContext));
            _packageUsageDetailRepository = new Lazy<IPackageUsageDetailRepository>(() => new PackageUsageDetailRepository(repositoryContext));
            _packageDetailRepository = new Lazy<IPackageDetailRepository>(() => new PackageDetailRepository(repositoryContext));
            _productAtWarehouseRepository = new Lazy<IProductAtWarehouseRepository>(() => new ProductAtWarehouseRepository(repositoryContext));
            _goodsIssuedDetailProductAtWarehouseRepository = new Lazy<IGoodsIssuedDetailProductAtWarehouseRepository>(() => new GoodsIssuedDetailProductAtWarehouseRepostitory(repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IBrandRepository Brand => _brandRepository.Value;
        public IServiceRepository Service => _serviceRepository.Value;
        public IInvoiceRepository Invoice => _invoiceRepository.Value;
        public IProductRepository Product => _productRepository.Value;
        public ICarPartRepository CarPart => _carPartRepository.Value;
        public ICarModelRepository CarModel => _carModelRepository.Value;
        public ISupplierRepository Supplier => _supplierRepository.Value;
        public IWorkplaceRepository Workplace => _workplaceRepository.Value;
        public ICarCategoryRepository CarCategory => _carCategoryRepository.Value;
        public IGoodsIssuedRepository GoodsIssued => _goodsIssuedRepository.Value;
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
        public IGoodsTransactionRepository GoodsTransaction => _goodsTransactionRepository.Value;
        public IGoodsIssuedDetailRepository GoodsIssuedDetail => _goodsIssuedDetaiRepository.Value;
        public IProductAtWarehouseRepository ProductAtWarehouse => _productAtWarehouseRepository.Value;
        public IInvoiceSellProductRepository InvoiceSellProduct => _invoiceSellProductRepository.Value;
        public IGoodsReceivedDetailRepository GoodsReceivedDetail => _goodsReceivedDetailRepository.Value;
        public IAppointmentRepository Appointment => _appointmentRepository.Value;
        public IAppointmentDetailPackageRepository AppointmentDetailPackage => _appointmentDetailPackageRepository.Value;
        public IAppointmentDetailRepository AppointmentDetail => _appointmentDetailRepository.Value;
        public IAppointmentPerDayRepository AppointmentPerDay => _appointmentPerDayRepository.Value;
        public IAppointmentReplacementPartRepository AppointmentReplacementPart => _appointmentReplacementPartRepository.Value;
        public IPackageRepository Package => _packageRepository.Value;
        public IPackageConditionRepository PackageCondition => _packageConditionRepository.Value;
        public IPackageFeedBackRepository PackageFeedBack => _packageFeedBackRepository.Value;
        public IPackageHistoryRepository PackageHistory => _packageHistoryRepository.Value;
        public IPackageImageRepository PackageImage => _packageImageRepository.Value;
        public IPackageUsageRepository PackageUsage => _packageUsageRepository.Value;
        public IPackageUsageDetailRepository PackageUsageDetail => _packageUsageDetailRepository.Value;
        public IPackageDetailRepository PackageDetail => _packageDetailRepository.Value;
        public IGoodsIssuedDetailProductAtWarehouseRepository GoodsIssuedDetailProductAtWarehouse => _goodsIssuedDetailProductAtWarehouseRepository.Value;
        public IProductAtGarageRepository ProductAtGarage => _productAtGarageRepository.Value;

        public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;

        public IInvoiceSellProductRepository InvoiceSellProductRepository => _invoiceSellProductRepository.Value;
        public IInvoiceSellProduct_ProductAtGarageRepository InvoiceSellProduct_ProductAtGarage => _invoiceSellProduct_ProductAtGarageRepository.Value;

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
