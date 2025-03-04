using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;
        private readonly Lazy<IDataShaper<BrandDto>> _brandShaper;
        private readonly Lazy<IDataShaper<ServiceDto>> _serviceShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShaper;
        private readonly Lazy<IDataShaper<CarPartDto>> _carPartShaper;
        private readonly Lazy<IDataShaper<SupplierDto>> _supplierShapper;
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<ServiceImageDto>> _serviceImageShaper;
        private readonly Lazy<IDataShaper<ProductImageDto>> _productImageShaper;
        private readonly Lazy<IDataShaper<GoodsReceivedDto>> _goodsReceivedShaper;
        private readonly Lazy<IDataShaper<ProductHistoryDto>> _productHistoryShaper;
        private readonly Lazy<IDataShaper<ServiceHistoryDto>> _serviceHistoryShaper;
        private readonly Lazy<IDataShaper<SupplierContactDto>> _supplierContactShaper;
        private readonly Lazy<IDataShaper<ProductCategoryDto>> _productCategoryShaper;
        private readonly Lazy<IDataShaper<CarPartCategoryDto>> _carPartCategoryShaper;
        private readonly Lazy<IDataShaper<ServiceFeedBackDto>> _serviceFeedBackShaper;
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
            _supplierShapper = new Lazy<IDataShaper<SupplierDto>>(
            () => new DataShaper<SupplierDto>(SupplierDto.PropertyInfos));

            _carPartCategoryShaper = new Lazy<IDataShaper<CarPartCategoryDto>>(
            () => new DataShaper<CarPartCategoryDto>(CarPartCategoryDto.PropertyInfos));

            _serviceImageShaper = new Lazy<IDataShaper<ServiceImageDto>>(
            () => new DataShaper<ServiceImageDto>(ServiceImageDto.PropertyInfos));

            _serviceHistoryShaper = new Lazy<IDataShaper<ServiceHistoryDto>>(
            () => new DataShaper<ServiceHistoryDto>(ServiceHistoryDto.PropertyInfos));

            _serviceFeedBackShaper = new Lazy<IDataShaper<ServiceFeedBackDto>>(
            () => new DataShaper<ServiceFeedBackDto>(ServiceFeedBackDto.PropertyInfos));
            _supplierContactShaper = new Lazy<IDataShaper<SupplierContactDto>>(
            () => new DataShaper<SupplierContactDto>(SupplierContactDto.PropertyInfos));
            _goodsReceivedShaper = new Lazy<IDataShaper<GoodsReceivedDto>>(
           () => new DataShaper<GoodsReceivedDto>(GoodsReceivedDto.PropertyInfos));
        }
        //.Value là thuộc tính của Lazy<T>, nó sẽ kích hoạt việc khởi tạo đối tượng nếu đối tượng đó chưa được khởi tạo trước đó. Nếu đối tượng đã được khởi tạo, thuộc tính .Value sẽ trả về đối tượng đó.
        public IDataShaper<UserDto> User => _userShaper.Value;
        public IDataShaper<BrandDto> Brand => _brandShaper.Value;
        public IDataShaper<ServiceDto> Service => _serviceShaper.Value;
        public IDataShaper<CarPartDto> CarPart => _carPartShaper.Value;
        public IDataShaper<ProductDto> Product => _productShaper.Value;
        public IDataShaper<SupplierDto> Supplier => _supplierShapper.Value;
        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;
        public IDataShaper<ServiceImageDto> ServiceImage => _serviceImageShaper.Value;
        public IDataShaper<ProductImageDto> ProductImage => _productImageShaper.Value;
        public IDataShaper<GoodsReceivedDto> GoodsReceived => _goodsReceivedShaper.Value;
        public IDataShaper<ProductHistoryDto> ProductHistory => _productHistoryShaper.Value;
        public IDataShaper<ServiceHistoryDto> ServiceHistory => _serviceHistoryShaper.Value;
        public IDataShaper<ProductCategoryDto> ProductCategory => _productCategoryShaper.Value;
        public IDataShaper<CarPartCategoryDto> CarPartCategory => _carPartCategoryShaper.Value;
        public IDataShaper<ServiceFeedBackDto> ServiceFeedback => _serviceFeedBackShaper.Value;
        public IDataShaper<SupplierContactDto> SupplierContact => _supplierContactShaper.Value;

    }
}
