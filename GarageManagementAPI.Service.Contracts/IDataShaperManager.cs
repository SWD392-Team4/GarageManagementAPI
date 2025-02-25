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

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<WorkplaceDto> Workplace { get; }
        IDataShaper<UserDto> User { get; }
        IDataShaper<BrandDto> Brand { get; }
        IDataShaper<ProductDto> Product { get; }
        IDataShaper<ProductHistoryDto> ProductHistory { get; }
        IDataShaper<ProductCategoryDto> ProductCategory { get; }
        IDataShaper<ProductImageDto> ProductImage { get; }
        IDataShaper<ServiceDto> Service { get; }
        IDataShaper<CarPartDto> CarPart { get; }
        IDataShaper<CarPartCategoryDto> CarPartCategory { get; }
    }
}
