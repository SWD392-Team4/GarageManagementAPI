using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<UserDto> User { get; }
        IDataShaper<BrandDto> Brand { get; }
        IDataShaper<CarCategoryDto> CarCategory { get; }
        IDataShaper<CarModelDto> CarModel { get; }
        IDataShaper<ServiceDto> Service { get; }
        IDataShaper<ProductDto> Product { get; }
        IDataShaper<CarPartDto> CarPart { get; }
        IDataShaper<SupplierDto> Supplier { get; }
        IDataShaper<WorkplaceDto> Workplace { get; }
        IDataShaper<GoodsIssuedDto> GoodsIssued { get; }
        IDataShaper<ServiceImageDto> ServiceImage { get; }
        IDataShaper<ProductImageDto> ProductImage { get; }
        IDataShaper<GoodsReceivedDto> GoodsReceived { get; }
        IDataShaper<ProductHistoryDto> ProductHistory { get; }
        IDataShaper<ServiceHistoryDto> ServiceHistory { get; }
        IDataShaper<ProductCategoryDto> ProductCategory { get; }
        IDataShaper<CarPartCategoryDto> CarPartCategory { get; }
        IDataShaper<ServiceFeedBackDto> ServiceFeedback { get; }
        IDataShaper<SupplierContactDto> SupplierContact { get; }
        IDataShaper<GoodsIssuedDetailDto> GoodsIssuedDetail { get; }
        IDataShaper<GoodsReceivedDetailDto> GoodsReceivedDetail { get; }
        IDataShaper<PackageImageDto> PackageImage { get; }
        IDataShaper<PackageDto> Package { get; }
        IDataShaper<PackageHistoryDto> PackageHistory { get; }
        IDataShaper<PackageConditionDto> PackageCondition { get; }
    }
}
