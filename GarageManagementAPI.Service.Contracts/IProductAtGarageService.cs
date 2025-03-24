using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using System.Dynamic;


namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductAtGarageService
    {
        Task<Result<ExpandoObject>> GetProductAtGarage(Guid productAtGarageid, bool trackChanges, string? include = null);
        Task<Result<IEnumerable<ExpandoObject>>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null);

        Task<Result<IEnumerable<ExpandoObject>>> GetProductsAtGarage(Guid garageId, ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null);

        public Task<Result<ExpandoObject>> GetProductByBarcodeByProductAtGarageAsync(string barcode, Guid garageId, ProductParameters productParameters, bool trackChanges, string? include = null);
    }
}
