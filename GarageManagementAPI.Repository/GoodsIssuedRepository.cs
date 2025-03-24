using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Repository
{
    public class GoodsIssuedRepository : RepositoryBase<GoodsIssued>, IGoodsIssuedRepository
    {
        public GoodsIssuedRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateGoodsIssuedAsync(GoodsIssued goodsIssued)
        {
            await base.CreateAsync(goodsIssued);
        }

        public void UpdateGoodsIssuedAsync(GoodsIssued goodsIssued)
        {
            base.Update(goodsIssued);
        }


        public async Task<GoodsIssued?> GetGoodsIssuedAsync(Guid goodsIssuedId, bool trackChanges, string? include = null)
        {
            var goodsIssued = include is null ?
              await FindByCondition(b => b.Id.Equals(goodsIssuedId), trackChanges).SingleOrDefaultAsync() :
              await FindByCondition(b => b.Id.Equals(goodsIssuedId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return goodsIssued;
;
        }

        public async Task<GoodsIssued?> GetGoodsIssuedByIdAndReferenceNumberAsync(string referenceNumber, Guid? goodsIssuedId, bool trackChanges)
        {
            var goodsIssued =
             await FindByCondition(b => !b.Id.Equals(goodsIssuedId) && b.ReferenceNumber.ToLower().Equals(referenceNumber.ToLower()), trackChanges).SingleOrDefaultAsync();
            return goodsIssued;
        }

        public async Task<PagedList<GoodsIssued>> GetGoodsIssuedsAsync(GoodsIssuedParameters goodsIssuedParameters, bool trackChanges, string? include = null)
        {
            var goodsIssueds = await FindAll(trackChanges)
             .SearchByTotalCost(goodsIssuedParameters.minTotalCost, goodsIssuedParameters.maxTotalCost)
             .SearchByReferenceNumber(goodsIssuedParameters.ReferenceNumber)
             .SearchByReInvoiceCode(goodsIssuedParameters.InvoiceCode)
             .SearchByCreateAt(goodsIssuedParameters.CreatedAt)
             .SearchByUpdateAt(goodsIssuedParameters.UpdatedAt)
             .Sort(goodsIssuedParameters.OrderBy)
             .IsInclude(include)
             .ToListAsync();

            return PagedList<GoodsIssued>.ToPagedList(
                goodsIssueds,
                goodsIssuedParameters.PageNumber,
                goodsIssuedParameters.PageSize
                );
        }

        public async Task<IEnumerable<ProductAtGarageRevenueDto>> GetPrices(int year, Guid? garageId, bool trackChanges)
        {
            var products = garageId == null
                             ? await FindByCondition(g => g.CreatedAt.Year == year, trackChanges)
                                                    .GroupBy(g => g.CreatedAt.Month)
                                                    .Select(p => new ProductAtGarageRevenueDto
                                                    {
                                                        Month = p.Key,
                                                        Prices = p.Sum(g => g.TotalCost)
                                                    })
                                                    .ToListAsync()
                             : await FindByCondition(p => p.CreatedAt.Year == year, trackChanges)
                                                       .Include(p => p.GoodsIssuedDetails)
                                                       .ThenInclude(g => g.ProductAtGarage)
                                                       .Where(p => p.GoodsIssuedDetails.Any(g => g.ProductAtGarage!.WorkplaceId == garageId))
                                                       .GroupBy(g => g.CreatedAt.Month)
                                                       .Select(p => new ProductAtGarageRevenueDto
                                                       {
                                                        Month = p.Key,
                                                        Prices = p.Sum(g => g.TotalCost)
                                                       })
                                                       .ToListAsync();
            return products;
        }

    }
}
