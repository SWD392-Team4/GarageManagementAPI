namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IWorkplaceService WorkplaceService { get; }

        IAuthenticationService AuthenticationService { get; }

        IEmployeeInfoService EmployeeInfoService { get; }

        IUserService UserService { get; }

        IMailService MailService { get; }

        IBrandService BrandService { get; }

        IProductService ProductService { get; }

        IProductHistoryService ProductHistoryService { get; }

        IProductCategoryService ProductCategoryService { get; }

        IProductImageService ProductImageService { get; }

        IServiceService ServiceService { get; }

        ICarPartService CarPartService { get; }

        ICarPartCategoryService CarPartCategoryService { get; }

        IMediaService MediaService { get; }

        ICarModelService CarModelService { get; }

        ICarCategoryService CarCategoryService { get; }
    }
}
