using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;
namespace GarageManagementAPI.Service.Contracts
{
    public interface IBrandService
    {
        public Task<Result<ExpandoObject>> GetBrandAsync(Guid brandId, BrandParameters brandParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetBrandsAsync(BrandParameters brans, bool trackChanges, string? include = null);
        public Task<Result<BrandDtoForUpdate>> GetBrandForPartiallyUpdate(Guid brandId, bool trackChanges);
        public Task<Result<BrandDto>> CreateBrandAsync(BrandDtoForCreation brandDtoForCreation);
        public Task<Result> UpdateBrand(Guid brandId, BrandDtoForUpdate brandDtoForUpdate, bool trackChanges);
       
    }
}
