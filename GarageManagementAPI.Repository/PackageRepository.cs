using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageRepository : RepositoryBase<Package>, IPackageRepository
    {
        public PackageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Package?> GetPacakgeByNameAsync(string packageName, bool trackChanges)
        {
            var package = await FindByCondition(p => p.PackageName.Equals(packageName), trackChanges)
                .Select(p => new Package
                {
                    Id = p.Id,
                    PackageName = p.PackageName,
                    Description = p.Description,
                    Type = p.Type,
                    Status = p.Status,
                    ServiceCategory = p.ServiceCategory,
                    CarCategoryId = p.CarCategoryId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    CarCategory = p.CarCategory,
                    PackageConditions = p.PackageConditions,
                    PackageImages = p.PackageImages,
                    PackageHistories = p.PackageHistories
            .OrderByDescending(ph => ph.CreatedAt).Where(ph => ph.Status.Equals(PackageHistoryStatus.Active))
            .Take(1)
            .ToList()
                })
                .FirstOrDefaultAsync();
            return package;
        }

        public async Task<Package?> GetPackageByIdAsync(Guid id, bool trackChanges)
        {
            var package = await FindByCondition(p => p.Id.Equals(id), trackChanges)
                .Select(p => new Package
                {
                    Id = p.Id,
                    PackageName = p.PackageName,
                    Description = p.Description,
                    Type = p.Type,
                    Status = p.Status,
                    ServiceCategory = p.ServiceCategory,
                    CarCategoryId = p.CarCategoryId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    CarCategory = p.CarCategory,
                    PackageConditions = p.PackageConditions,
                    PackageImages = p.PackageImages,
                    PackageHistories = p.PackageHistories
                    .OrderByDescending(ph => ph.CreatedAt).Where(ph => ph.Status.Equals(PackageHistoryStatus.Active))
                    .Take(1)
                    .ToList()
                })
                .SingleOrDefaultAsync();
            return package;
        }

        public async Task<PagedList<Package>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges)
        {
            var pacakges = await FindAll(trackChanges)
                .Sort(packageParameters.OrderBy)
                .Skip((packageParameters.PageNumber - 1) * packageParameters.PageSize)
                .Take(packageParameters.PageSize)
                .Select(p => new Package
                {
                    Id = p.Id,
                    PackageName = p.PackageName,
                    Description = p.Description,
                    Type = p.Type,
                    Status = p.Status,
                    ServiceCategory = p.ServiceCategory,
                    CarCategoryId = p.CarCategoryId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    CarCategory = p.CarCategory,
                    PackageConditions = p.PackageConditions,
                    PackageImages = p.PackageImages,
                    PackageHistories = p.PackageHistories
                    .OrderByDescending(ph => ph.CreatedAt).Where(ph => ph.Status.Equals(PackageHistoryStatus.Active))
                    .Take(1)
                    .ToList()
                })
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .CountAsync();


            return new PagedList<Package>(
                pacakges,
                count,
                packageParameters.PageNumber,
                packageParameters.PageSize);
        }
    }
}
