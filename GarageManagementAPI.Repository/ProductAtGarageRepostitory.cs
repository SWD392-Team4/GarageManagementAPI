using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class ProductAtGarageRepostitory : RepositoryBase<ProductAtGarage>, IProductAtGarageRepository
    {
        public ProductAtGarageRepostitory(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateProductAtGarageAsync(ProductAtGarage productAtGarage)
        {
            await base.CreateAsync(productAtGarage);
        }

        public async Task<PagedList<ProductAtGarage>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null)
        {
            var productsAtgarages= await FindAll(trackChanges)
                                            .SearchByQuantityProduct(productAtGarageParameters.minQuantity, productAtGarageParameters.maxQuantity)
                                            //.SearchByCreated(productAtGarageParameters.CreatedAt)
                                            .ToListAsync();
            return PagedList<ProductAtGarage>.ToPagedList(productsAtgarages,
                productAtGarageParameters.PageNumber,
                productAtGarageParameters.PageSize);
        }

        public async Task<ProductAtGarage?> GetProductAtGarage(Guid productAtGarageId, bool trackChanges, string? include = null)
        {
            var productAtGarage = include == null ? await FindByCondition(pat => pat.Id.Equals(productAtGarageId), trackChanges).SingleOrDefaultAsync() : await FindByCondition(pat => pat.Id.Equals(productAtGarageId), false).IsInclude(include).SingleOrDefaultAsync();
            return productAtGarage;
        }

        public async Task<ProductAtGarage?> GetProductAtGarage(Guid productId, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateProductGarage(ProductAtGarage productAtGarage)
        {
            base.Update(productAtGarage);
        }
    }
}
