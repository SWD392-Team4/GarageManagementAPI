using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

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
             .Skip((goodsIssuedParameters.PageNumber - 1) * goodsIssuedParameters.PageSize)
             .Take(goodsIssuedParameters.PageSize)
             .ToListAsync();

            return PagedList<GoodsIssued>.ToPagedList(
                goodsIssueds,
                goodsIssuedParameters.PageNumber,
                goodsIssuedParameters.PageSize
                );
        }

        public void UpdateGoodsIssuedAsync(GoodsIssued goodsIssued)
        {
            base.Update(goodsIssued);
        }
    }
}
