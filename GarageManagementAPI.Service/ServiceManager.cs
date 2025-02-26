using AutoMapper;
using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GarageManagementAPI.Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IWorkplaceService> _workplaceService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IEmployeeInfoService> _employeeInfoService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductHistoryService> _productHistoryService;
        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IMediaService> _mediaService;
        private readonly Lazy<IServiceService> _serviceService;
        private readonly Lazy<ICarPartService> _carPartService;
        private readonly Lazy<ICarPartCategoryService> _carPartCategoryService;
        private readonly Lazy<ICarCategoryService> _carCategoryService;
        private readonly Lazy<ICarModelService> _carModelService;
        private readonly Lazy<IAppointmentService> _appointmentService;

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

            _appointmentService = new Lazy<IAppointmentService>(() =>
           new AppointmentService(
            repositoryManager,
            mapper,
            dataShaper));

            _mediaService = new Lazy<IMediaService>(() =>
            new MediaService(cloudinaryConfiguration));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IWorkplaceService WorkplaceService => _workplaceService.Value;

        public IMailService MailService => _mailService.Value;

        public IEmployeeInfoService EmployeeInfoService => _employeeInfoService.Value;

        public IUserService UserService => _userService.Value;

        public IBrandService BrandService => _brandService.Value;

        public IProductService ProductService => _productService.Value;

        public IProductHistoryService ProductHistoryService => _productHistoryService.Value;

        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;

        public IProductImageService ProductImageService => _productImageService.Value;

        public IServiceService ServiceService => _serviceService.Value;

        public ICarPartService CarPartService => _carPartService.Value;

        public ICarPartCategoryService CarPartCategoryService => _carPartCategoryService.Value;

        public IMediaService MediaService => _mediaService.Value;

        public ICarModelService CarModelService => _carModelService.Value;

        public ICarCategoryService CarCategoryService => _carCategoryService.Value;

        public IAppointmentService AppointmentService => _appointmentService.Value;
    }
}
