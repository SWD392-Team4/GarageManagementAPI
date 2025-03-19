using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class ProductHistoryRepository : RepositoryBase<ProductHistory>, IProductHistoryRepository
    {
        public ProductHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async new Task CreateAsync(ProductHistory productHisotry)
        {
            productHisotry.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(productHisotry);
        }

        public async Task<PagedList<ProductHistory>> GetProductHistoryByIdProductAsync(Guid productId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            var productsQuery = FindByCondition(p =>
                  p.ProductId.Equals(productId), trackChanges)
                .SearchByPrice(productHistoryParameters.ProductPrice)
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
            var products = await FindAll(trackChanges)
                .SearchByPrice(productHistoryParameters.ProductPrice)
                .Sort(productHistoryParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();

            // Trả về kết quả dưới dạng PagedList
            return PagedList<ProductHistory>.ToPagedList(
                products,
                productHistoryParameters.PageNumber,
                productHistoryParameters.PageSize
            );
        }

        public async Task<IEnumerable<ProductHistory>> GetProductHistoriesAsync(IEnumerable<Guid> productIds, bool trackChanges)
        {
            var productHistories = await FindByCondition(ph => productIds.Contains(ph.ProductId), trackChanges)
                    .Include(ph => ph.Product)
                    .GroupBy(ph => ph.ProductId)
                    .Select(g => g.OrderByDescending(s => s.CreatedAt).First())
                    .ToListAsync();

            return productHistories;
        }

        public async Task<ProductHistory?> GetProductHistory(Guid productId, bool trackChanges)
        {
            var productHistory = await FindByCondition(ph => ph.ProductId.Equals(productId), trackChanges).OrderByDescending(s => s.CreatedAt).FirstOrDefaultAsync();

            return productHistory;
        }
        public async Task<ProductHistory?> GetProductHistoryByGoodsIssuedDetails(Guid productId)
        {
            var productHistory = await FindByCondition(ph => ph.ProductId == productId, false)
                                     .OrderByDescending(ph => ph.CreatedAt)
                                     .FirstOrDefaultAsync();
            return productHistory;
        }
    }
}
