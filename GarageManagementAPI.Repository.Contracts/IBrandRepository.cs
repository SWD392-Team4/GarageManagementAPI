using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IBrandRepository : IRepositoryBase<Brand>
    {
        Task<Brand?> GetBrandByIdAsync(Guid brandId, bool trackChanges, string? include = default);
        Task<Brand?> GetBrandByIdAndNameAsync(string name, Guid? brandId, bool trackChanges);
        Task<PagedList<Brand>> GetBrandsAsync(BrandParameters brandParameters, bool trackChanges, string? include = default);
        Task CreateBrandAsync(Brand brand);
        void UpdateBrandAsync(Brand brand);
    }
}
