using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IInvoiceSellProduct_ProductAtGarageRepository
    {
        Task CreatInvoiceSellProduct_ProductAtGarageAsync(InvoiceSellProduct_ProductAtGarage invoiceSellProduct_ProductAtGarage);
    }
}
