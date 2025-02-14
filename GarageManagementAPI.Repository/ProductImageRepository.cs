

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.RequestFeatures;

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

        public async Task<PagedList<ProductImage>> GetProductImgByIdProductAsync(Guid productId, ProductImageParameters productImageParameters, bool trackChanges, string? include = null)
        {
            var imgsQuery = FindByCondition(pm => pm.ProductId.Equals(productId), trackChanges)
                      .SearchByStatus(productImageParameters.Status)
                      .Sort(productImageParameters.OrderBy)
                      .IsInclude(include)
                      .AsQueryable();
            //AsQueryable() sử dụng để chuyển một tập hợp dữ liệu (như danh sách hoặc mảng) sang kiểu IQueryable<T>


            var productImgs = await imgsQuery
            .Skip((productImageParameters.PageNumber - 1) * productImageParameters.PageSize)
            .Take(productImageParameters.PageSize)
            .ToListAsync();

            var count = await imgsQuery.CountAsync();

            return new PagedList<ProductImage>(
               productImgs,
               count,
               productImageParameters.PageNumber,
               productImageParameters.PageSize
           );
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
