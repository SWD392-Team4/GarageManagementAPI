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

        IProductHistoryService ProductHistoryService { get; }

        IProductCategoryService ProductCategoryService { get; }

        IProductImageService ProductImageService { get; }

        IServiceService ServiceService { get; }

        ICarPartService CarPartService { get; }

        ICarPartCategoryService CarPartCategoryService { get; }

        IMediaService MediaService { get; }

        ICarModelService CarModelService { get; }

        ICarCategoryService CarCategoryService { get; }

        IAppointmentService AppointmentService { get; }
    }

}
