namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IMailService MailService { get; }
        IUserService UserService { get; }
        IBrandService BrandService { get; }
        IMediaService MediaService { get; }
        IServiceService ServiceService { get; }
        IProductService ProductService { get; }
        ICarPartService CarPartService { get; }
        ISupplierService SupplierService { get; }
        ICarModelService CarModelService { get; }
        IWorkplaceService WorkplaceService { get; }
        ICarCategoryService CarCategoryService { get; }
        IServiceFeedbackService ServiceFeedback { get; }
        IServiceImageService ServiceImageService { get; }
        IEmployeeInfoService EmployeeInfoService { get; }
        IProductImageService ProductImageService { get; }
        IGoodsReceivedService GoodsReceivedService { get; }
        IProductHistoryService ProductHistoryService { get; }
        IServiceHistoryService ServiceHistoryService { get; }
        IAuthenticationService AuthenticationService { get; }
        IProductCategoryService ProductCategoryService { get; }
        ICarPartCategoryService CarPartCategoryService { get; }
        ISupplierContactService SupplierContactService { get; }

    }
}
