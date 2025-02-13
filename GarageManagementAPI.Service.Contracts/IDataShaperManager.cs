using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<WorkplaceDto> Workplace { get; }

        IDataShaper<UserDto> User { get; }
        IDataShaper<Shared.DataTransferObjects.Brand.BrandDto> Brand { get; }
        IDataShaper<Shared.DataTransferObjects.Product.ProductDtoWithPrice> Product { get; }
        IDataShaper<Shared.DataTransferObjects.ProductHistory.ProductHistoryDto> ProductHistory { get; }
        IDataShaper<Shared.DataTransferObjects.ProductCategory.ProductCategoryDto> ProductCategory { get; }
    }
}
