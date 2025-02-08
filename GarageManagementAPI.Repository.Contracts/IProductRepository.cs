using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = default);
        Task<PagedList<Product>> GetProductsAsync(ProductParameters userParameters, bool trackChanges, bool isEmployee, string? include = default);
    }
}
