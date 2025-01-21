namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceManager
    {
        IGarageService GarageService { get; }

        IEmployeeService EmployeeService { get; }

        IAuthenticationService AuthenticationService { get; }
    }
}
