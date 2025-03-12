using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsIssuedDetailProductAtWarehouseRepository
    {
        Task CreateGoodsIssuedDetailProductAtWarehouse(GoodsIssuedDetail_ProductAtWarehouse goodsIssuedDetailProductAtWarehouse);
    }
}
