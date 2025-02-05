using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;

        public DataShaperManager()
        {
            _workplaceShaper = new Lazy<IDataShaper<WorkplaceDto>>(
                () => new DataShaper<WorkplaceDto>(WorkplaceDto.PropertyInfos));

            _userShaper = new Lazy<IDataShaper<UserDto>>(
               () => new DataShaper<UserDto>(UserDto.PropertyInfos));
        }

        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;

        public IDataShaper<UserDto> User => _userShaper.Value;
    }
}
