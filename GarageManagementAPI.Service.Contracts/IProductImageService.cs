using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductImageService
    {
        public Task<Result<ProductImageDto>> CreateProductImageAsync(Guid productId, string imgId, string imgUrl);
        public Task<Result> UpdateProductImageAsync(Guid productImageId, ProductImageDtoForUpdate productImageDtoForUpdate, bool trackChanges);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductImageByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductImagesAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = null);
    }
}
