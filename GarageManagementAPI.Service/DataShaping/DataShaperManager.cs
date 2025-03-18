using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;

namespace GarageManagementAPI.Service.DataShaping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<UserDto>> _userShaper;
        private readonly Lazy<IDataShaper<BrandDto>> _brandShaper;
        private readonly Lazy<IDataShaper<ServiceDto>> _serviceShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShaper;
        private readonly Lazy<IDataShaper<CarPartDto>> _carPartShaper;
        private readonly Lazy<IDataShaper<CarModelDto>> _carModelShaper;
        private readonly Lazy<IDataShaper<CarCategoryDto>> _carCategoryShaper;
        private readonly Lazy<IDataShaper<SupplierDto>> _supplierShapper;
        private readonly Lazy<IDataShaper<WorkplaceDto>> _workplaceShaper;
        private readonly Lazy<IDataShaper<GoodsIssuedDto>> _goodsIssuedShaper;
        private readonly Lazy<IDataShaper<ServiceImageDto>> _serviceImageShaper;
        private readonly Lazy<IDataShaper<ProductImageDto>> _productImageShaper;
        private readonly Lazy<IDataShaper<GoodsReceivedDto>> _goodsReceivedShaper;
        private readonly Lazy<IDataShaper<ProductHistoryDto>> _productHistoryShaper;
        private readonly Lazy<IDataShaper<ServiceHistoryDto>> _serviceHistoryShaper;
        private readonly Lazy<IDataShaper<SupplierContactDto>> _supplierContactShaper;
        private readonly Lazy<IDataShaper<ProductCategoryDto>> _productCategoryShaper;
        private readonly Lazy<IDataShaper<CarPartCategoryDto>> _carPartCategoryShaper;
        private readonly Lazy<IDataShaper<ServiceFeedBackDto>> _serviceFeedBackShaper;
        private readonly Lazy<IDataShaper<GoodsIssuedDetailDto>> _goodsIssuedDetailShaper;
        private readonly Lazy<IDataShaper<GoodsReceivedDetailDto>> _goodsReceivedDetailShaper;
        private readonly Lazy<IDataShaper<PackageImageDto>> _packageImageShaper;
        private readonly Lazy<IDataShaper<ProductAtGarageDto>> _productAtGarageShaper;
        private readonly Lazy<IDataShaper<PackageDto>> _packageShaper;
        private readonly Lazy<IDataShaper<PackageHistoryDto>> _packageHistoryShaper;
        private readonly Lazy<IDataShaper<PackageConditionDto>> _packageConditionShaper;
        private readonly Lazy<IDataShaper<ProductAtWarehouseDto>> _productAtWarehouseShaper;
        private readonly Lazy<IDataShaper<AppointmentDto>> _appointmentShaper;
        private readonly Lazy<IDataShaper<InvoiceDto>> _invoiceShaper;
        private readonly Lazy<IDataShaper<InvoiceSellProductDto>> _invoiceSellProductShaper;
        private readonly Lazy<IDataShaper<CarConditionImageDto>> _carConditionImageShaper;

        public DataShaperManager()
        {
            _workplaceShaper = new Lazy<IDataShaper<WorkplaceDto>>(
                () => new DataShaper<WorkplaceDto>(WorkplaceDto.PropertyInfos));

            _userShaper = new Lazy<IDataShaper<UserDto>>(
               () => new DataShaper<UserDto>(UserDto.PropertyInfos));

            _brandShaper = new Lazy<IDataShaper<BrandDto>>(
               () => new DataShaper<BrandDto>(BrandDto.PropertyInfos));

            _carCategoryShaper = new Lazy<IDataShaper<CarCategoryDto>>(
               () => new DataShaper<CarCategoryDto>(CarCategoryDto.PropertyInfos));

            _carModelShaper = new Lazy<IDataShaper<CarModelDto>>(
              () => new DataShaper<CarModelDto>(CarModelDto.PropertyInfos));

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

            _goodsReceivedDetailShaper = new Lazy<IDataShaper<GoodsReceivedDetailDto>>(
            () => new DataShaper<GoodsReceivedDetailDto>(GoodsReceivedDetailDto.PropertyInfos));

            _goodsIssuedShaper = new Lazy<IDataShaper<GoodsIssuedDto>>(
            () => new DataShaper<GoodsIssuedDto>(GoodsIssuedDto.PropertyInfos));

            _packageImageShaper = new Lazy<IDataShaper<PackageImageDto>>(
            () => new DataShaper<PackageImageDto>(PackageImageDto.PropertyInfos));

            _packageShaper = new Lazy<IDataShaper<PackageDto>>(
            () => new DataShaper<PackageDto>(PackageDto.PropertyInfos));

            _packageHistoryShaper = new Lazy<IDataShaper<PackageHistoryDto>>(
            () => new DataShaper<PackageHistoryDto>(PackageHistoryDto.PropertyInfos));

            _packageConditionShaper = new Lazy<IDataShaper<PackageConditionDto>>(
            () => new DataShaper<PackageConditionDto>(PackageConditionDto.PropertyInfos));

            _goodsIssuedDetailShaper = new Lazy<IDataShaper<GoodsIssuedDetailDto>>(
           () => new DataShaper<GoodsIssuedDetailDto>(GoodsIssuedDetailDto.PropertyInfos));

            _productAtWarehouseShaper = new Lazy<IDataShaper<ProductAtWarehouseDto>>(
           () => new DataShaper<ProductAtWarehouseDto>(ProductAtWarehouseDto.PropertyInfos));

            _appointmentShaper = new Lazy<IDataShaper<AppointmentDto>>(
           () => new DataShaper<AppointmentDto>(AppointmentDto.PropertyInfos));
            _productAtGarageShaper = new Lazy<IDataShaper<ProductAtGarageDto>>(
         () => new DataShaper<ProductAtGarageDto>(ProductAtGarageDto.PropertyInfos));

            _invoiceShaper = new Lazy<IDataShaper<InvoiceDto>>(
          () => new DataShaper<InvoiceDto>(InvoiceDto.PropertyInfos));

            _invoiceSellProductShaper = new Lazy<IDataShaper<InvoiceSellProductDto>>(
         () => new DataShaper<InvoiceSellProductDto>(InvoiceSellProductDto.PropertyInfos));

            _carConditionImageShaper = new Lazy<IDataShaper<CarConditionImageDto>>(
                () => new DataShaper<CarConditionImageDto>(CarConditionImageDto.PropertyInfos));
        }
        //.Value là thuộc tính của Lazy<T>, nó sẽ kích hoạt việc khởi tạo đối tượng nếu đối tượng đó chưa được khởi tạo trước đó. Nếu đối tượng đã được khởi tạo, thuộc tính .Value sẽ trả về đối tượng đó.
        public IDataShaper<UserDto> User => _userShaper.Value;
        public IDataShaper<BrandDto> Brand => _brandShaper.Value;
        public IDataShaper<ServiceDto> Service => _serviceShaper.Value;
        public IDataShaper<CarPartDto> CarPart => _carPartShaper.Value;
        public IDataShaper<ProductDto> Product => _productShaper.Value;
        public IDataShaper<CarModelDto> CarModel => _carModelShaper.Value;
        public IDataShaper<SupplierDto> Supplier => _supplierShapper.Value;
        public IDataShaper<WorkplaceDto> Workplace => _workplaceShaper.Value;
        public IDataShaper<GoodsIssuedDto> GoodsIssued => _goodsIssuedShaper.Value;
        public IDataShaper<ServiceImageDto> ServiceImage => _serviceImageShaper.Value;
        public IDataShaper<ProductImageDto> ProductImage => _productImageShaper.Value;
        public IDataShaper<GoodsReceivedDto> GoodsReceived => _goodsReceivedShaper.Value;
        public IDataShaper<ProductHistoryDto> ProductHistory => _productHistoryShaper.Value;
        public IDataShaper<ServiceHistoryDto> ServiceHistory => _serviceHistoryShaper.Value;
        public IDataShaper<ProductCategoryDto> ProductCategory => _productCategoryShaper.Value;
        public IDataShaper<CarPartCategoryDto> CarPartCategory => _carPartCategoryShaper.Value;
        public IDataShaper<ServiceFeedBackDto> ServiceFeedback => _serviceFeedBackShaper.Value;
        public IDataShaper<SupplierContactDto> SupplierContact => _supplierContactShaper.Value;
        public IDataShaper<ProductAtGarageDto> ProductAtGarage => _productAtGarageShaper.Value;
        public IDataShaper<GoodsIssuedDetailDto> GoodsIssuedDetail => _goodsIssuedDetailShaper.Value;
        public IDataShaper<GoodsReceivedDetailDto> GoodsReceivedDetail => _goodsReceivedDetailShaper.Value;
        public IDataShaper<PackageImageDto> PackageImage => _packageImageShaper.Value;
        public IDataShaper<PackageDto> Package => _packageShaper.Value;
        public IDataShaper<ProductAtWarehouseDto> ProductAtWarehouse => _productAtWarehouseShaper.Value;
        public IDataShaper<PackageHistoryDto> PackageHistory => _packageHistoryShaper.Value;
        public IDataShaper<PackageConditionDto> PackageCondition => _packageConditionShaper.Value;
        public IDataShaper<CarCategoryDto> CarCategory => _carCategoryShaper.Value;
        public IDataShaper<AppointmentDto> Appointment => _appointmentShaper.Value;
        public IDataShaper<InvoiceDto> Invoice => _invoiceShaper.Value;
        public IDataShaper<InvoiceSellProductDto> InvoiceSellProduct => _invoiceSellProductShaper.Value;

        public IDataShaper<CarConditionImageDto> CarConditionImage => _carConditionImageShaper.Value;
    }
}
