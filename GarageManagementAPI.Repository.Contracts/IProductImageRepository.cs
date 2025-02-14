using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductImageRepository : IRepositoryBase<ProductImage>
    {
        Task<PagedList<ProductImage>> GetProductImgByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = default);
        Task<PagedList<ProductImage>> GetProductImgsAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = default);
        Task CreateProductImgAsync(ProductImage productImage);
        void UpdateProductImg(ProductImage productImage);
    }
}
