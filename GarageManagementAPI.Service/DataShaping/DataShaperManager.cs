using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;
        private readonly Lazy<IDataShaper<BrandDto>> _brandShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShaper;

        public DataShaperManager()
        {
            _workplaceShaper = new Lazy<IDataShaper<WorkplaceDto>>(
                () => new DataShaper<WorkplaceDto>(WorkplaceDto.PropertyInfos));

            _userShaper = new Lazy<IDataShaper<UserDto>>(
               () => new DataShaper<UserDto>(UserDto.PropertyInfos));

            _brandShaper = new Lazy<IDataShaper<BrandDto>>(
               () => new DataShaper<BrandDto>(BrandDto.PropertyInfos));

            _productShaper = new Lazy<IDataShaper<ProductDto>>(
              () => new DataShaper<ProductDto>(ProductDto.PropertyInfos));
        }

        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;

        public IDataShaper<UserDto> User => _userShaper.Value;

        public IDataShaper<BrandDto> Brand => _brandShaper.Value;
        public IDataShaper<ProductDto> Product => _productShaper.Value;
    }
}
