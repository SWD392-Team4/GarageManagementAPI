using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Repository
{
    public class InvoiceSellProduct_ProductAtGarageRepository : RepositoryBase<InvoiceSellProduct_ProductAtGarage>, IInvoiceSellProduct_ProductAtGarageRepository
    {
        public InvoiceSellProduct_ProductAtGarageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task CreatInvoiceSellProduct_ProductAtGarageAsync(InvoiceSellProduct_ProductAtGarage invoiceSellProduct_ProductAtGarage)
        {
            await base.CreateAsync(invoiceSellProduct_ProductAtGarage);
        }
    }
}
