using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;


namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductAtGarageService
    {
        Task<Result<ExpandoObject>> GetProductAtGarage(Guid productAtGarageid, bool trackChanges, string? include = null);
        Task<Result<IEnumerable<ExpandoObject>>> GetProductAtWarehouses(ProductAtGarageParameters productAtGarageParameters, bool trackChanges , string? include = null);
    }
}
