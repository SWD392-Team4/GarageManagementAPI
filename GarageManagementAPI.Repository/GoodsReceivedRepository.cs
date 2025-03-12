using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Repository.Extensions;

namespace GarageManagementAPI.Repository
{
    public class GoodsReceivedRepository : RepositoryBase<GoodsReceived>, IGoodsReceivedRepository
    {
        public GoodsReceivedRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateGoodsReceivedAsync(GoodsReceived goodsReceived)
        {
            await base.CreateAsync(goodsReceived);
        }

        public async Task<GoodsReceived?> GetGoodsReceivedAsync(Guid goodsReceivedId, bool trackChanges, string? include = null)
        {
            var goods = include is null ?
            await FindByCondition(p => p.Id.Equals(goodsReceivedId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(p => p.Id.Equals(goodsReceivedId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return goods;
        }

        public async Task<GoodsReceived?> GetGoodsReceivedByRefereneceNumberAsync(Guid? goodsReceivedId, string refereneceNumber, bool trackChanges, string? include = null)
        {
            var goods = goodsReceivedId == null ? await FindByCondition(g => g.RefereneceNumber.ToLower().Equals(refereneceNumber.ToLower()), trackChanges).SingleOrDefaultAsync()
                                                  : await FindByCondition(g => g.RefereneceNumber.ToLower().Equals(refereneceNumber.ToLower()) && g.Id != goodsReceivedId, trackChanges).SingleOrDefaultAsync();
            return goods;
        }

        public async Task<GoodsReceived?> GetGoodsReceivedByInvoiceCodeAsync(Guid? goodsReceivedId, string invoiceCode, bool trackChanges, string? include = null)
        {
            var goods = goodsReceivedId == null ? await FindByCondition(g => g.RefereneceNumber.Equals(invoiceCode), trackChanges).SingleOrDefaultAsync()
                                                  : await FindByCondition(g => g.RefereneceNumber.Equals(invoiceCode) && g.Id != goodsReceivedId, trackChanges).SingleOrDefaultAsync();
            return goods;
        }

        public async Task<GoodsReceived?> GetGoodsReceivedByAddressAsync(Guid? goodsReceivedId, GoodsReceived goodsReceived, bool trackChanges, string? include = null)
        {
            var address = goodsReceived.SourceAddress!.Trim();
            var province = goodsReceived.SourceProvince!.Trim();
            var district = goodsReceived.SourceDistrict!.Trim();
            var ward = goodsReceived.SourceWards!.Trim();

            var goods = goodsReceivedId == null ? await FindByCondition(x =>
                x.SourceAddress.Trim().Equals(address) &&
                x.SourceProvince.Trim().Equals(province) &&
                x.SourceDistrict.Trim().Equals(district) &&
                x.SourceWards.Trim().Equals(ward)
                ,trackChanges).SingleOrDefaultAsync() 
                :
                await FindByCondition(x =>
                x.SourceAddress.Trim().Equals(address) &&
                x.SourceProvince.Trim().Equals(province) &&
                x.SourceDistrict.Trim().Equals(district) &&
                x.SourceWards.Trim().Equals(ward)
                && x.Id != goodsReceivedId
                , trackChanges).SingleOrDefaultAsync();

            return goods;
        }

        public async Task<PagedList<GoodsReceived>> GetGoodsReceivedsAsync(GoodsReceivedParameters goodsReceivedParameters, bool trackChanges, string? include = null)
        {
            var goodsReceived = await FindAll(trackChanges)
                 .SearchByRefereneceNumber(goodsReceivedParameters.RefereneceNumber)
                 .SearchByInvoiceCode(goodsReceivedParameters.InvoiceCode)
                 .SearchByStatus(goodsReceivedParameters.Status)
                 .SearchByPrice(goodsReceivedParameters.MinPrice, goodsReceivedParameters.MaxPrice)
                 .SearchByDate(goodsReceivedParameters.CreatedAt)
                 .SearchByDate(goodsReceivedParameters.UpdatedAt)
                 .SearchBySourceAddress(goodsReceivedParameters.SourceAddress)
                 .SearchBySourceDistrict(goodsReceivedParameters.SourceDistrict)
                 .SearchBySourceProvince(goodsReceivedParameters.SourceProvince)
                 .SearchBySourceWards(goodsReceivedParameters.SourceWards)
                 .SearchByStatus(goodsReceivedParameters.Status)
                 .IsInclude(include)
                 .ToListAsync();

            return PagedList<GoodsReceived>.ToPagedList(
                goodsReceived,
                goodsReceivedParameters.PageNumber,
                goodsReceivedParameters.PageSize
            );
        }

        public void UpdateGoodsReceived(GoodsReceived goodsReceived)
        {
            base.Update(goodsReceived);
        }

        public async Task<PagedList<GoodsReceived>> GetGoodsReceivedsAsync(Guid warehouseId, GoodsReceivedParameters goodsReceivedParameters, bool trackChanges, string? include = null)
        {
            var goodsReceived = await FindByCondition(gr => gr.WarehouseId.Equals(warehouseId),trackChanges)
                .SearchByRefereneceNumber(goodsReceivedParameters.RefereneceNumber)
                .SearchByInvoiceCode(goodsReceivedParameters.InvoiceCode)
                .SearchByStatus(goodsReceivedParameters.Status)
                .SearchByPrice(goodsReceivedParameters.MinPrice, goodsReceivedParameters.MaxPrice)
                .SearchByDate(goodsReceivedParameters.CreatedAt)
                .SearchByDate(goodsReceivedParameters.UpdatedAt)
                .SearchBySourceAddress(goodsReceivedParameters.SourceAddress)
                .SearchBySourceDistrict(goodsReceivedParameters.SourceDistrict)
                .SearchBySourceProvince(goodsReceivedParameters.SourceProvince)
                .SearchBySourceWards(goodsReceivedParameters.SourceWards)
                .SearchByStatus(goodsReceivedParameters.Status)
                .IsInclude(include)
                .ToListAsync();

            return PagedList<GoodsReceived>.ToPagedList(
                goodsReceived,
                goodsReceivedParameters.PageNumber,
                goodsReceivedParameters.PageSize
            );
        }
    }
}
