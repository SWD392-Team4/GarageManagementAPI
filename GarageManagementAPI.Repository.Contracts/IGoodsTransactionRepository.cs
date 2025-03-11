using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsTransaction;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsTransactionRepository
    {
        Task CreateGoodsTransaction(GoodsTransaction goodsTransaction);
    }
}
