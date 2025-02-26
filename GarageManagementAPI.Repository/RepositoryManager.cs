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
        private readonly Lazy<IServiceRepository> _serviceRepository;
        private readonly Lazy<ICarPartRepository> _carPartRepository;
        private readonly Lazy<ICarPartCategoryRepository> _carPartCategoryRepository;
        private readonly Lazy<ICarCategoryRepository> _carCategoryRepository;
        private readonly Lazy<ICarModelRepository> _carModelRepository;
        private readonly Lazy<IAppointmentRepository> _appointmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _workplaceRepository = new Lazy<IWorkplaceRepository>(() => new WorkplaceRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _employeeInfoRepository = new Lazy<IEmployeeInfoRepository>(() => new EmployeeInfoRepository(repositoryContext));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _productHistoryRepository = new Lazy<IProductHistoryRepository>(() => new ProductHistoryRepository(repositoryContext));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));
            _carPartRepository = new Lazy<ICarPartRepository>(() => new CarPartRepository(repositoryContext));
            _carPartCategoryRepository = new Lazy<ICarPartCategoryRepository>(() => new CarPartCategoryRepository(repositoryContext));
            _productImageRepository = new Lazy<IProductImageRepository>(() => new ProductImageRepository(repositoryContext));
            _serviceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(repositoryContext));
            _carCategoryRepository = new Lazy<ICarCategoryRepository>(() => new CarCategoryRepository(repositoryContext));
            _carModelRepository = new Lazy<ICarModelRepository>(() => new CarModelRepository(repositoryContext));
            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));

        }

        public IWorkplaceRepository Workplace => _workplaceRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public IEmployeeInfoRepository EmployeeInfo => _employeeInfoRepository.Value;

        public IBrandRepository Brand => _brandRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        public IProductHistoryRepository ProductHistory => _productHistoryRepository.Value;

        public IProductCategoryRepository ProductCategory => _productCategoryRepository.Value;

        public IProductImageRepository ProductImage => _productImageRepository.Value;

        public IServiceRepository Service => _serviceRepository.Value;

        public ICarPartRepository CarPart => _carPartRepository.Value;

        public ICarPartCategoryRepository CarPartCategory => _carPartCategoryRepository.Value;

        public ICarCategoryRepository CarCategory => _carCategoryRepository.Value;

        public ICarModelRepository CarModel => _carModelRepository.Value;

        public IAppointmentRepository Appointment => _appointmentRepository.Value;

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
