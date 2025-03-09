using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Entities.ConfigurationModels;

namespace GarageManagementAPI.Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IMediaService> _mediaService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IServiceService> _serviceService;
        private readonly Lazy<ICarPartService> _carPartService;
        private readonly Lazy<ICarModelService> _carModelService;
        private readonly Lazy<ISupplierService> _supplierService;
        private readonly Lazy<IWorkplaceService> _workplaceService;
        private readonly Lazy<IGoodsIssuedService> _goodsIssuedService;
        private readonly Lazy<ICarCategoryService> _carCategoryService;
        private readonly Lazy<IEmployeeInfoService> _employeeInfoService;
        private readonly Lazy<IServiceImageService> _serviceImageService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IGoodsReceivedService> _goodsReceivedService;
        private readonly Lazy<IProductHistoryService> _productHistoryService;
        private readonly Lazy<IServiceHistoryService> _serviceHistoryService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<ICarPartCategoryService> _carPartCategoryService;
        private readonly Lazy<ISupplierContactService> _supplierContactService;
        private readonly Lazy<IAppointmentService> _appointmentService;
        private readonly Lazy<IServiceFeedbackService> _serviceFeedbackService;
        private readonly Lazy<IGoodsIssuedDetailService> _goodsIssuedDetailService;
        private readonly Lazy<IGoodsReceivedDetailService> _goodsReceivedDetailService;
        private readonly Lazy<IPackageService> _packageService;
        private readonly Lazy<IPackageConditionService> _packageConditionService;
        private readonly Lazy<IPackageFeedBackService> _packageFeedBackService;
        private readonly Lazy<IPackageUsageService> _packageUsageService;
        private readonly Lazy<IPackageUsageDetailService> _packageUsageDetailService;
        private readonly Lazy<IPackageImageService> _packageImageService;
        private readonly Lazy<IProductAtWarehouseService> _productAtWarehouseService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            IMapper mapper,
            IDataShaperManager dataShaper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptionsSnapshot<JwtConfiguration> jwtConfiguration,
            IOptionsSnapshot<MailConfiguration> mailConfiguration,
            IOptionsSnapshot<CloudinaryConfigurations> cloudinaryConfiguration)
        {


            _authenticationService = new Lazy<IAuthenticationService>(
                () => new AuthenticationService(
                    repositoryManager,
                    mapper,
                    userManager,
                    signInManager,
                    jwtConfiguration));

            _workplaceService = new Lazy<IWorkplaceService>(
                () => new WorkplaceService(
                    repositoryManager,
                    mapper,
                    dataShaper));

            _mailService = new Lazy<IMailService>(
                () => new MailService(mailConfiguration));

            _employeeInfoService = new Lazy<IEmployeeInfoService>(() =>
            new EmployeeInfoService(
                repositoryManager,
                    mapper));

            _userService = new Lazy<IUserService>(() =>
            new UserService(
                repositoryManager,
                mapper,
                userManager,
                dataShaper));

            _brandService = new Lazy<IBrandService>(() =>
            new BrandService(
               repositoryManager,
               mapper,
               dataShaper));

            _productService = new Lazy<IProductService>(() =>
            new ProductService(
              repositoryManager,
              mapper,
              dataShaper));

            _productHistoryService = new Lazy<IProductHistoryService>(() =>
            new ProductHistoryService(
             repositoryManager,
             mapper,
             dataShaper));

            _productCategoryService = new Lazy<IProductCategoryService>(() =>
            new ProductCategoryService(
             repositoryManager,
             mapper,
             dataShaper));

            _productImageService = new Lazy<IProductImageService>(() =>
            new ProductImageService(
             repositoryManager,
             mapper,
             dataShaper));


            _serviceService = new Lazy<IServiceService>(() =>
            new ServiceService(
             repositoryManager,
             mapper,
             dataShaper));

            _carPartService = new Lazy<ICarPartService>(() =>
            new CarPartService(
             repositoryManager,
             mapper,
             dataShaper));

            _carPartCategoryService = new Lazy<ICarPartCategoryService>(() =>
           new CarPartCategoryService(
            repositoryManager,
            mapper,
            dataShaper));

            _carCategoryService = new Lazy<ICarCategoryService>(() =>
           new CarCategoryService(
            repositoryManager,
            mapper,
            dataShaper));

            _carModelService = new Lazy<ICarModelService>(() =>
           new CarModelService(
            repositoryManager,
            mapper,
            dataShaper));

            _serviceImageService = new Lazy<IServiceImageService>(() =>
            new ServiceImageService(
            repositoryManager,
            mapper,
            dataShaper));

            _serviceHistoryService = new Lazy<IServiceHistoryService>(() =>
            new ServiceHistoryService(
            repositoryManager,
            mapper,
            dataShaper));

            _serviceFeedbackService = new Lazy<IServiceFeedbackService>(() =>
            new ServiceFeedBackService(
            repositoryManager,
            mapper,
            dataShaper));

            _carCategoryService = new Lazy<ICarCategoryService>(() =>
           new CarCategoryService(
            repositoryManager,
            mapper,
            dataShaper));

            _carModelService = new Lazy<ICarModelService>(() =>
           new CarModelService(
            repositoryManager,
            mapper,
            dataShaper));

            // _appointmentService = new Lazy<IAppointmentService>(() =>
            //new AppointmentService(
            // repositoryManager,
            // mapper,
            // dataShaper));

            _supplierService = new Lazy<ISupplierService>(() =>
            new SupplierService(
            repositoryManager,
            mapper,
            dataShaper));
            _mediaService = new Lazy<IMediaService>(() =>
            new MediaService(cloudinaryConfiguration));

            _supplierContactService = new Lazy<ISupplierContactService>(() =>
            new SupplierContactService(
            repositoryManager,
            mapper,
            dataShaper));

            _goodsReceivedService = new Lazy<IGoodsReceivedService>(() =>
            new GoodsReceivedService(
            repositoryManager,
            mapper,
            dataShaper));

            _goodsReceivedDetailService = new Lazy<IGoodsReceivedDetailService>(() =>
            new GoodsReceivedDetailService(
            repositoryManager,
            mapper,
            dataShaper));
            _productAtWarehouseService = new Lazy<IProductAtWarehouseService>(() =>
            new ProductAtWarehouseService(
            repositoryManager,
            mapper,
            dataShaper));
            _goodsIssuedService = new Lazy<IGoodsIssuedService>(() =>
              new GoodsIssuedService(
              repositoryManager,
              mapper,
              dataShaper));
            _mediaService = new Lazy<IMediaService>(() =>
            new MediaService(cloudinaryConfiguration));
            _goodsIssuedDetailService = new Lazy<IGoodsIssuedDetailService>(() =>
             new GoodsIssuedDetailService(
             repositoryManager,
             mapper,
             dataShaper));
            _mediaService = new Lazy<IMediaService>(() =>
            new MediaService(cloudinaryConfiguration));

            _packageService = new Lazy<IPackageService>(() => new PackageService(repositoryManager, mapper, dataShaper));

            _packageConditionService = new Lazy<IPackageConditionService>(() => new PackageConditionService(repositoryManager, mapper, dataShaper));

            _packageFeedBackService = new Lazy<IPackageFeedBackService>(() => new PackageFeedBackService(repositoryManager, mapper, dataShaper));

            _packageUsageService = new Lazy<IPackageUsageService>(() => new PackageUsageService(repositoryManager, mapper, dataShaper));

            _packageUsageDetailService = new Lazy<IPackageUsageDetailService>(() => new PackageUsageDetailService(repositoryManager, mapper, dataShaper));

            _packageImageService = new Lazy<IPackageImageService>(() => new PackageImageService(repositoryManager, mapper, dataShaper));
        }

        public IUserService UserService => _userService.Value;
        public IMailService MailService => _mailService.Value;
        public IBrandService BrandService => _brandService.Value;
        public IMediaService MediaService => _mediaService.Value;
        public IServiceService ServiceService => _serviceService.Value;
        public IProductService ProductService => _productService.Value;
        public ICarPartService CarPartService => _carPartService.Value;
        public ISupplierService SupplierService => _supplierService.Value;
        public ICarModelService CarModelService => _carModelService.Value;
        public IWorkplaceService WorkplaceService => _workplaceService.Value;
        public IGoodsIssuedService GoodsIssuedService => _goodsIssuedService.Value;
        public ICarCategoryService CarCategoryService => _carCategoryService.Value;
        public IServiceImageService ServiceImageService => _serviceImageService.Value;
        public IProductImageService ProductImageService => _productImageService.Value;
        public IEmployeeInfoService EmployeeInfoService => _employeeInfoService.Value;
        public IServiceFeedbackService ServiceFeedback => _serviceFeedbackService.Value;
        public IGoodsReceivedService GoodsReceivedService => _goodsReceivedService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IProductHistoryService ProductHistoryService => _productHistoryService.Value;
        public IServiceHistoryService ServiceHistoryService => _serviceHistoryService.Value;
        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;
        public ICarPartCategoryService CarPartCategoryService => _carPartCategoryService.Value;
        public ISupplierContactService SupplierContactService => _supplierContactService.Value;
        public IGoodsIssuedDetailService GoodsIssuedDetailService => _goodsIssuedDetailService.Value;
        public IGoodsReceivedDetailService GoodsReceivedDetailService => _goodsReceivedDetailService.Value;
        public IAppointmentService AppointmentService => _appointmentService.Value;
        public IPackageService PackageService => _packageService.Value;
        public IPackageConditionService PackageConditionService => _packageConditionService.Value;
        public IPackageFeedBackService PackageFeedBackService => _packageFeedBackService.Value;
        public IPackageUsageService PackageUsageService => _packageUsageService.Value;
        public IPackageUsageDetailService PackageUsageDetailService => _packageUsageDetailService.Value;
        public IPackageImageService PackageImageService => _packageImageService.Value;
        public IProductAtWarehouseService ProductAtWarehouseService => _productAtWarehouseService.Value;
    }
}
