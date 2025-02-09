using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<WorkplaceDto> Workplace { get; }

        IDataShaper<UserDto> User { get; }
        IDataShaper<BrandDto> Brand { get; }
        IDataShaper<ProductDto> Product { get; }
    }
}
