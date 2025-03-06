using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateProductImgAsync(ProductImage productImage)
        {
            await base.CreateAsync(productImage);
        }

        public void UpdateProductImg(ProductImage productImage)
        {
            base.Update(productImage);
        }
        public async Task<ProductImage?> GetProductImgAsync(Guid productImgId, bool trackChanges, string? include = null)
        {
            var productImg = await FindByCondition(p => p.Id == productImgId, false)
                                      .FirstOrDefaultAsync();
            return productImg;
        }

        public async Task<PagedList<ProductImage>> GetProductImgByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = null)
        {
            var productImgs = await FindByCondition(pm => pm.ProductId.Equals(productId), trackChanges)
                      .SearchByStatus(productImageParameters.Status)
                      .Sort(productImageParameters.OrderBy)
                      .IsInclude(include)
                      .ToListAsync();

            return PagedList<ProductImage>.ToPagedList(
               productImgs,
               productImageParameters.PageNumber,
               productImageParameters.PageSize
           );
        }

        public async Task<ProductImage?> GetProductImgByStatusAndIdProductAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var productImg = await FindByCondition(p => p.Status == ProductImageStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
                                      .FirstOrDefaultAsync();
            return productImg;
        }

        public Task<ProductImage?> GetProductImgByLinkAndIdProductAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var productImg = FindByCondition(p => p.ProductId.Equals(productId), false)
                             .OrderByDescending(p => p.UpdatedAt)
                             .FirstOrDefaultAsync();
            return productImg;
        }

        public async Task<PagedList<ProductImage>> GetProductImgsAsync(ProductImageParameters productImageParameters, bool trackChanges, string? include = null)
        {
            var imgsQuery = FindAll(trackChanges)
                     .SearchByStatus(productImageParameters.Status)
                     .Sort(productImageParameters.OrderBy)
                     .IsInclude(include)
                     .AsQueryable();
            var productImgs = await imgsQuery
            .Skip((productImageParameters.PageNumber - 1) * productImageParameters.PageSize)
            .Take(productImageParameters.PageSize)
            .ToListAsync();
            //ToListAsync(): IQueryable<T> hoặc IEnumerable<T> thành một danh sách (List<T>)
            var count = await imgsQuery.CountAsync();

            return new PagedList<ProductImage>(
               productImgs,
               count,
               productImageParameters.PageNumber,
               productImageParameters.PageSize
           );
        }


    }
}
