using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductImageService
    {
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductImageByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductImagesAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = null);
    }
}
