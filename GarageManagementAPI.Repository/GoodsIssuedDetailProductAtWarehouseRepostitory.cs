using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class GoodsIssuedDetailProductAtWarehouseRepostitory : RepositoryBase<GoodsIssuedDetail_ProductAtWarehouse>, IGoodsIssuedDetailProductAtWarehouseRepository
    {
        public GoodsIssuedDetailProductAtWarehouseRepostitory(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateGoodsIssuedDetailProductAtWarehouse(GoodsIssuedDetail_ProductAtWarehouse goodsIssuedDetailProductAtWarehouse)
        {
            await base.CreateAsync(goodsIssuedDetailProductAtWarehouse);
        }
    }
}