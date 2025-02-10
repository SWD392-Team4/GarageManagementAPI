using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PagedList<ProductHistory>> GetProductByIdAsync(Guid productHistoryId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            var productsQuery = FindByCondition(p =>
                  p.ProductId.Equals(productHistoryId), trackChanges)
                .SearchByPrice(productHistoryParameters.ProductPrice) // Tìm kiếm theo tên sản phẩm
                .SearchByStatus(productHistoryParameters.Status)
                .Sort(productHistoryParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            var products = await productsQuery
            .Skip((productHistoryParameters.PageNumber - 1) * productHistoryParameters.PageSize)
            .Take(productHistoryParameters.PageSize)
            .ToListAsync();

            var count = await productsQuery.CountAsync();

            return new PagedList<ProductHistory>(
                products,
                count,
                productHistoryParameters.PageNumber,
                productHistoryParameters.PageSize
            );
        }

        public async Task<PagedList<ProductHistory>> GetProductsAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách products theo các điều kiện
            var productsQuery = FindByCondition(p =>
                   p.ProductPrice >= 0,
                    trackChanges)
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

        public void UpdateProductHistory(ProductHistory productHistory)
        {
            base.Update(productHistory);
        }
    }
}
