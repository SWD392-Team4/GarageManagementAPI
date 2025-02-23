using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductImageRepository : IRepositoryBase<ProductImage>
    {
        Task<PagedList<ProductImage>> GetProductImgByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = default);
        Task<ProductImage?> GetProductImgByStatusAndIdProductAsync(Guid productId, bool trackChanges, string? include = default);
        Task<ProductImage?> GetProductImgByLinkAndIdProductAsync(Guid productId, bool trackChanges, string? include = default);
        Task<PagedList<ProductImage>> GetProductImgsAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = default);
        Task CreateProductImgAsync(ProductImage productImage);
        void UpdateProductImg(ProductImage productImage);
    }
}
