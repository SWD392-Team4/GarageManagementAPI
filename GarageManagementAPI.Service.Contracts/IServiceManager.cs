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
        ICarModelService CarModelService { get; }
        IWorkplaceService WorkplaceService { get; }
        ICarCategoryService CarCategoryService { get; }
        IServiceImageService ServiceImageService { get; }
        IEmployeeInfoService EmployeeInfoService { get; }
        IProductImageService ProductImageService { get; }
        IProductHistoryService ProductHistoryService { get; }
        IAuthenticationService AuthenticationService { get; }
        IProductCategoryService ProductCategoryService { get; }
        ICarPartCategoryService CarPartCategoryService { get; }
       
    }
}
