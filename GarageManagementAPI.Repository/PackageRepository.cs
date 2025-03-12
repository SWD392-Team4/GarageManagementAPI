using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting;

namespace GarageManagementAPI.Repository
{
    public class PackageRepository : RepositoryBase<Package>, IPackageRepository
    {
        public PackageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Package?> GetPackageByNameAsync(string packageName, bool trackChanges)
        {
            var package = await FindByCondition(p => p.PackageName.Equals(packageName), trackChanges)
                .Include(p => p.PackageImages)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
                .SingleOrDefaultAsync();
            return package;
        }

        public async Task<Package?> GetPackageByIdAsync(Guid id, bool trackChanges)
        {
            var package = await FindByCondition(p => p.Id.Equals(id), trackChanges)
                .Include(p => p.PackageImages)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
                .SingleOrDefaultAsync();
            return package;
        }

        public async Task<PagedList<Package>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges)
        {
            var pacakges = await FindAll(trackChanges)
                .FilterByCarCategory(packageParameters.CarCategoryId)
                .FilterByServiceCategory(packageParameters.ServiceCategory)
                .FilterByPriceRange(packageParameters.MinPrice, packageParameters.MaxPrice)
                .FilterByPackageName(packageParameters.PackageName)
                .FilterByDescription(packageParameters.Description)
                .FilterByPackageType(packageParameters.Type)
                .FilterByPackageStatus(packageParameters.Status)
                .FilterByValidityPeriod(packageParameters.ValidityPeriod)
                .FilterByTimeUnit(packageParameters.TimeUnit)
                .FilterByUsageLimit(packageParameters.UsageLimit)
                .FilterByCreatedAt(packageParameters.CreatedAt)
                .FilterByUpdatedAt(packageParameters.UpdatedAt)
                .Sort(packageParameters.OrderBy)
                .Skip((packageParameters.PageNumber - 1) * packageParameters.PageSize)
                .Take(packageParameters.PageSize)
                .Include(p => p.PackageImages)
                .Include(p => p.PackageConditions)
                .Include(p => p.CarCategory)
                .AsSplitQuery()
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .FilterByCarCategory(packageParameters.CarCategoryId)
                .FilterByServiceCategory(packageParameters.ServiceCategory)
                .FilterByPriceRange(packageParameters.MinPrice, packageParameters.MaxPrice)
                .FilterByPackageName(packageParameters.PackageName)
                .FilterByDescription(packageParameters.Description)
                .FilterByPackageType(packageParameters.Type)
                .FilterByPackageStatus(packageParameters.Status)
                .FilterByValidityPeriod(packageParameters.ValidityPeriod)
                .FilterByTimeUnit(packageParameters.TimeUnit)
                .FilterByUsageLimit(packageParameters.UsageLimit)
                .FilterByCreatedAt(packageParameters.CreatedAt)
                .FilterByUpdatedAt(packageParameters.UpdatedAt)
                .CountAsync();


            return new PagedList<Package>(
                pacakges,
                count,
                packageParameters.PageNumber,
                packageParameters.PageSize);
        }

        public async new Task CreateAsync(Package package)
        {
            package.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            package.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            package.Status = PackageStatus.Active;
            await base.CreateAsync(package);
        }

        public async Task<PagedList<Package>> GetPackagesByServiceIdAsync(Guid serviceId, PackageParameters packageParameters, bool trackChanges)
        {
            var pacakges = await FindByCondition(e => e.PackageHistories.Any(ph => ph.Services.Any(s => s.Id.Equals(serviceId))), trackChanges)
               .FilterByCarCategory(packageParameters.CarCategoryId)
               .FilterByServiceCategory(packageParameters.ServiceCategory)
               .FilterByPriceRange(packageParameters.MinPrice, packageParameters.MaxPrice)
               .FilterByPackageName(packageParameters.PackageName)
               .FilterByDescription(packageParameters.Description)
               .FilterByPackageType(packageParameters.Type)
               .FilterByPackageStatus(packageParameters.Status)
               .FilterByValidityPeriod(packageParameters.ValidityPeriod)
               .FilterByTimeUnit(packageParameters.TimeUnit)
               .FilterByUsageLimit(packageParameters.UsageLimit)
               .FilterByCreatedAt(packageParameters.CreatedAt)
               .FilterByUpdatedAt(packageParameters.UpdatedAt)
               .Sort(packageParameters.OrderBy)
               .Skip((packageParameters.PageNumber - 1) * packageParameters.PageSize)
               .Take(packageParameters.PageSize)
               .Include(p => p.PackageImages)
               .Include(p => p.PackageConditions)
               .Include(p => p.CarCategory)
               .AsSplitQuery()
               .ToListAsync();

            var count = await FindByCondition(e => e.PackageHistories.Any(ph => ph.Services.Any(s => s.Id.Equals(serviceId))), trackChanges)
                .FilterByCarCategory(packageParameters.CarCategoryId)
                .FilterByServiceCategory(packageParameters.ServiceCategory)
                .FilterByPriceRange(packageParameters.MinPrice, packageParameters.MaxPrice)
                .FilterByPackageName(packageParameters.PackageName)
                .FilterByDescription(packageParameters.Description)
                .FilterByPackageType(packageParameters.Type)
                .FilterByPackageStatus(packageParameters.Status)
                .FilterByValidityPeriod(packageParameters.ValidityPeriod)
                .FilterByTimeUnit(packageParameters.TimeUnit)
                .FilterByUsageLimit(packageParameters.UsageLimit)
                .FilterByCreatedAt(packageParameters.CreatedAt)
                .FilterByUpdatedAt(packageParameters.UpdatedAt)
                .CountAsync();


            return new PagedList<Package>(
                pacakges,
                count,
                packageParameters.PageNumber,
                packageParameters.PageSize);
        }
    }
}
