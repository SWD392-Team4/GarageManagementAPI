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
        ICarPartCategoryService CarPartCategoryService { get; }
        ICarModelService CarModelService { get; }
        ICarCategoryService CarCategoryService { get; }
        IAppointmentService AppointmentService { get; }
        IServiceFeedbackService ServiceFeedback { get; }
        IWorkplaceService WorkplaceService { get; }
        IServiceImageService ServiceImageService { get; }
        IServiceHistoryService ServiceHistoryService { get; }
    }

}
