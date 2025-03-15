namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IUserService UserService { get; }
        IBrandService BrandService { get; }
        IInvoiceService InvoiceService { get; }
        IMediaService MediaService { get; }
        IServiceService ServiceService { get; }
        IProductService ProductService { get; }
        ICarPartService CarPartService { get; }
        IPackageService PackageService { get; }
        ICarModelService CarModelService { get; }
        ISupplierService SupplierService { get; }
        IWorkplaceService WorkplaceService { get; }
        ICarCategoryService CarCategoryService { get; }
        IAppointmentService AppointmentService { get; }
        IGoodsIssuedService GoodsIssuedService { get; }
        IServiceFeedbackService ServiceFeedback { get; }
        IProductImageService ProductImageService { get; }
        IServiceImageService ServiceImageService { get; }
        IEmployeeInfoService EmployeeInfoService { get; }
        IPackageUsageService PackageUsageService { get; }
        IPackageImageService PackageImageService { get; }
        IGoodsReceivedService GoodsReceivedService { get; }
        IServiceHistoryService ServiceHistoryService { get; }
        IProductHistoryService ProductHistoryService { get; }
        IProductCategoryService ProductCategoryService { get; }
        ICarPartCategoryService CarPartCategoryService { get; }
        ISupplierContactService SupplierContactService { get; }
        IProductAtGarageService ProductAtGarageService { get; }
        IPackageFeedBackService PackageFeedBackService { get; }
        IPackageConditionService PackageConditionService { get; }
        IGoodsIssuedDetailService GoodsIssuedDetailService { get; }
        IAppointmentDetailService AppointmentDetailService { get; }
        IInvoiceSellProductService InvoiceSellProductService { get; }
        IProductAtWarehouseService ProductAtWarehouseService { get; }
        IPackageUsageDetailService PackageUsageDetailService { get; }
        IGoodsReceivedDetailService GoodsReceivedDetailService { get; }
        IAppointmentDetailPackageService AppointmentDetailPackageService { get; }
        IAppointmentReplacementPartService AppointmentReplacementPartService { get; }

    }
}
