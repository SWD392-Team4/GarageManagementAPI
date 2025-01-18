using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<EmployeeDto> EmployeeShaper { get; }

        IDataShaper<GarageDto> GarageShaper { get; }
    }
}
