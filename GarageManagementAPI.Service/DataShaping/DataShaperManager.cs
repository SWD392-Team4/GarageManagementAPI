using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;
        private readonly Lazy<IDataShaper<BrandDto>> _brandShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShaper;
        private readonly Lazy<IDataShaper<ProductHistoryDto>> _productHistoryShaper;
        private readonly Lazy<IDataShaper<ProductCategoryDto>> _productCategoryShaper;
        private readonly Lazy<IDataShaper<ProductImageDto>> _productImageShaper;
        private readonly Lazy<IDataShaper<ServiceDto>> _serviceShaper;
        private readonly Lazy<IDataShaper<CarPartDto>> _carPartShaper;
        private readonly Lazy<IDataShaper<CarPartCategoryDto>> _carPartCategoryShaper;

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

            _productHistoryShaper = new Lazy<IDataShaper<ProductHistoryDto>>(
              () => new DataShaper<ProductHistoryDto>(ProductHistoryDto.PropertyInfos));

            _productCategoryShaper = new Lazy<IDataShaper<ProductCategoryDto>>(
              () => new DataShaper<ProductCategoryDto>(ProductCategoryDto.PropertyInfos));

            _productImageShaper = new Lazy<IDataShaper<ProductImageDto>>(
            () => new DataShaper<ProductImageDto>(ProductImageDto.PropertyInfos));

            _serviceShaper = new Lazy<IDataShaper<ServiceDto>>(
            () => new DataShaper<ServiceDto>(ServiceDto.PropertyInfos));

            _carPartShaper = new Lazy<IDataShaper<CarPartDto>>(
            () => new DataShaper<CarPartDto>(CarPartDto.PropertyInfos));

            _carPartCategoryShaper = new Lazy<IDataShaper<CarPartCategoryDto>>(
            () => new DataShaper<CarPartCategoryDto>(CarPartCategoryDto.PropertyInfos));

        }
        //.Value là thuộc tính của Lazy<T>, nó sẽ kích hoạt việc khởi tạo đối tượng nếu đối tượng đó chưa được khởi tạo trước đó. Nếu đối tượng đã được khởi tạo, thuộc tính .Value sẽ trả về đối tượng đó.
        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;
        public IDataShaper<UserDto> User => _userShaper.Value;
        public IDataShaper<BrandDto> Brand => _brandShaper.Value;
        public IDataShaper<ProductDto> Product => _productShaper.Value;
        public IDataShaper<ProductCategoryDto> ProductCategory => _productCategoryShaper.Value;
        public IDataShaper<ProductHistoryDto> ProductHistory => _productHistoryShaper.Value;
        public IDataShaper<ProductImageDto> ProductImage => _productImageShaper.Value;
        public IDataShaper<ServiceDto> Service => _serviceShaper.Value;
        public IDataShaper<CarPartDto> CarPart => _carPartShaper.Value;
        public IDataShaper<CarPartCategoryDto> CarPartCategory => _carPartCategoryShaper.Value;
    }
}
