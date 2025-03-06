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
                .Include(p => p.PackageImages)
                .Include(p => p.PackageHistories.OrderByDescending(ph => ph.CreatedAt).Take(1))
                .Include(p => p.PackageConditions)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
                .SingleOrDefaultAsync();
            return package;
        }

        public async Task<Package?> GetPackageByIdAsync(Guid id, bool trackChanges)
        {
            var package = await FindByCondition(p => p.Id.Equals(id), trackChanges)
                .Include(p => p.PackageImages)
                .Include(p => p.PackageHistories.OrderByDescending(ph => ph.CreatedAt).Take(1))
                .Include(p => p.PackageConditions)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
                .SingleOrDefaultAsync();
            return package;
        }

        public async Task<PagedList<Package>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges)
        {
            var pacakges = await FindAll(trackChanges)
                .Sort(packageParameters.OrderBy)
                .Skip((packageParameters.PageNumber - 1) * packageParameters.PageSize)
                .Take(packageParameters.PageSize)
                .Include(p => p.PackageImages)
                .Include(p => p.PackageHistories.OrderByDescending(ph => ph.CreatedAt).Take(1))
                .Include(p => p.PackageConditions)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
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
