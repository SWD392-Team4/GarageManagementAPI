namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IWorkplaceService WorkplaceService { get; }

        IAuthenticationService AuthenticationService { get; }

        IMailService MailService { get; }
    }
}
