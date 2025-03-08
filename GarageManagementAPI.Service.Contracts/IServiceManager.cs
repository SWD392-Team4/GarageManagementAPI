namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IUserService UserService { get; }
        IBrandService BrandService { get; }
        IMediaService MediaService { get; }
        IServiceService ServiceService { get; }
        IProductService ProductService { get; }
        IProductHistoryService ProductHistoryService { get; }
        IProductCategoryService ProductCategoryService { get; }
        IProductImageService ProductImageService { get; }
        ICarPartService CarPartService { get; }
        ISupplierService SupplierService { get; }
        ICarModelService CarModelService { get; }
        IWorkplaceService WorkplaceService { get; }
        ICarCategoryService CarCategoryService { get; }
        IServiceFeedbackService ServiceFeedback { get; }
        IServiceImageService ServiceImageService { get; }
        IEmployeeInfoService EmployeeInfoService { get; }
        IGoodsReceivedService GoodsReceivedService { get; }
        IServiceHistoryService ServiceHistoryService { get; }
        ICarPartCategoryService CarPartCategoryService { get; }
        ISupplierContactService SupplierContactService { get; }
        IGoodsIssuedDetailService GoodsIssuedDetailService { get; }
        IGoodsReceivedDetailService GoodsReceivedDetailService { get; }
        IAppointmentService AppointmentService { get; }
        IPackageService PackageService { get; }
        IPackageConditionService PackageConditionService { get; }
        IPackageFeedBackService PackageFeedBackService { get; }
        IPackageUsageService PackageUsageService { get; }
        IPackageUsageDetailService PackageUsageDetailService { get; }
        IPackageImageService PackageImageService { get; }
        IGoodsIssuedService GoodsIssuedService { get; }

    }
}
