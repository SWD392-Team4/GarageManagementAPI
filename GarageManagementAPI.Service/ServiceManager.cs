using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GarageManagementAPI.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGarageService> _garageService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            IMapper mapper,
            IDataShaperManager dataShaper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _garageService = new Lazy<IGarageService>(
                () => new GarageService(
                    repositoryManager, 
                    mapper, 
                    dataShaper));

            _employeeService = new Lazy<IEmployeeService>(
                () => new EmployeeService(
                    repositoryManager, 
                    mapper, 
                    dataShaper));

            _authenticationService = new Lazy<IAuthenticationService>(
                () => new AuthenticationService(
                    mapper,
                    userManager,
                    configuration));
        }
        public IGarageService GarageService => _garageService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
