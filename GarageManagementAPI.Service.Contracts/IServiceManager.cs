namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IWorkplaceService WorkplaceService { get; }

        IAuthenticationService AuthenticationService { get; }

        IEmployeeInfoService EmployeeInfoService { get; }

        IMailService MailService { get; }
    }
}
