using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;


namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductAtGarageService
    {
        Task<Result<ExpandoObject>> GetProductAtGarage(Guid productAtGarageid, bool trackChanges, string? include = null);
        Task<Result<IEnumerable<ExpandoObject>>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges , string? include = null);

        Task<Result<IEnumerable<ProductAtGarageDto>>> GetProductsAtGarage(Guid userId, bool trackChanges, string? include = null);
    }
}
