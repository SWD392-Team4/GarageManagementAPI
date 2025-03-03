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

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<UserDto> User { get; }
        IDataShaper<BrandDto> Brand { get; }
        IDataShaper<ProductDto> Product { get; }
        IDataShaper<CarPartDto> CarPart { get; }
        IDataShaper<ServiceDto> Service { get; }
        IDataShaper<WorkplaceDto> Workplace { get; }
        IDataShaper<ServiceImageDto> ServiceImage { get; }
        IDataShaper<SupplierDto> Supplier { get; }
        IDataShaper<ProductImageDto> ProductImage { get; }
        IDataShaper<ProductHistoryDto> ProductHistory { get; }
        IDataShaper<ServiceHistoryDto> ServiceHistory { get; }
        IDataShaper<ProductCategoryDto> ProductCategory { get; }
        IDataShaper<CarPartCategoryDto> CarPartCategory { get; }
        IDataShaper<ServiceFeedBackDto> ServiceFeedback { get; }
    }
}
