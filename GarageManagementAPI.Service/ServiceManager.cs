using AutoMapper;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;

namespace GarageManagementAPI.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGarageService> _garageService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _garageService = new Lazy<IGarageService>(() => new GarageService(repositoryManager, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, mapper));
        }
        public IGarageService GarageService => _garageService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
