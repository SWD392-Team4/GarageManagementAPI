using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<GarageDto>> _garageShaper;
        private readonly Lazy<IDataShaper<EmployeeDto>> _employeeShaper;

        public DataShaperManager()
        {
            _garageShaper = new Lazy<IDataShaper<GarageDto>>(
                () => new DataShaper<GarageDto>(GarageDto.PropertyInfos));

            _employeeShaper = new Lazy<IDataShaper<EmployeeDto>>(
                () => new DataShaper<EmployeeDto>(EmployeeDto.PropertyInfos));
        }

        public IDataShaper<EmployeeDto> EmployeeShaper => _employeeShaper.Value;

        public IDataShaper<GarageDto> GarageShaper => _garageShaper.Value;
    }
}
