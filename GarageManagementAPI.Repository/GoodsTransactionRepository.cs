using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Repository
{
    public class GoodsTransactionRepository : RepositoryBase<GoodsTransaction>, IGoodsTransactionRepository
    {
        public GoodsTransactionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateGoodsTransaction(GoodsTransaction goodsTransaction)
        {
            await base.CreateAsync(goodsTransaction);
        }
    }
}
