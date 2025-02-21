using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;


namespace GarageManagementAPI.Repository
{
    public class ProductHistoryRepository : RepositoryBase<ProductHistory>, IProductHistoryRepository
    {
        public ProductHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateProductHisotoryAsync(ProductHistory productHisotry)
        {
            await base.CreateAsync(productHisotry);
        }

        public void UpdateProductHistory(ProductHistory productHistory)
        {
            base.Update(productHistory);
        }

        public async Task<PagedList<ProductHistory>> GetProductHistoryByIdProductAsync(Guid productId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            var productsQuery = FindByCondition(p =>
                  p.ProductId.Equals(productId), trackChanges)
                .SearchByPrice(productHistoryParameters.ProductPrice)
                .SearchByStatus(productHistoryParameters.Status)
                .Sort(productHistoryParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            var productHistories = await productsQuery
            .Skip((productHistoryParameters.PageNumber - 1) * productHistoryParameters.PageSize)
            .Take(productHistoryParameters.PageSize)
            .ToListAsync();

            var count = await productsQuery.CountAsync();

            return new PagedList<ProductHistory>(
                productHistories,
                count,
                productHistoryParameters.PageNumber,
                productHistoryParameters.PageSize
            );
        }

        public async Task<PagedList<ProductHistory>> GetProductHistoryAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách products theo các điều kiện
            var productsQuery = FindAll(trackChanges)
                .SearchByPrice(productHistoryParameters.ProductPrice) // Tìm kiếm theo tên sản phẩm
                .SearchByStatus(productHistoryParameters.Status)
                .Sort(productHistoryParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            // Lấy danh sách sản phẩm sau khi phân trang
            var products = await productsQuery
                .Skip((productHistoryParameters.PageNumber - 1) * productHistoryParameters.PageSize)
                .Take(productHistoryParameters.PageSize)
                .ToListAsync();

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await productsQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<ProductHistory>(
                products,
                count,
                productHistoryParameters.PageNumber,
                productHistoryParameters.PageSize
            );
        }

        public Task<ProductHistory?> GetProductHistoryByPriceAndIdProductAsync(Guid productId, decimal price, bool trackChanges, string? include = null)
        {
         var productHistory = FindByCondition(p => p.ProductId.Equals(productId) && p.ProductPrice == price, false)
                .OrderByDescending(p => p.UpdatedAt)
                .FirstOrDefaultAsync();
            return productHistory;
        }

        public Task<ProductHistory?> GetProductHistoryByStatusAndIdProductAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var productHistory = FindByCondition(p => p.Status == ProductHistoryStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
                                   .FirstOrDefaultAsync();
            return productHistory;
        }
    }
}
