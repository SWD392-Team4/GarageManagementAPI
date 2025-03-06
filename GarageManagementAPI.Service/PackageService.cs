using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using System.Dynamic;
using System.Net;

namespace GarageManagementAPI.Service
{
    public class PackageService : IPackageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<ExpandoObject>> CreatePackage(PackageDtoForCreation packageDtoForCreation, List<(string? ImageId, string? ImageLink)>? imageTuples = null, string? fields = null)
        {
            var carCategoryCheck = await _repoManager.CarCategory.GetCarCategoryAsync(packageDtoForCreation.CarCategoryId!.Value, trackChanges: true);
            if (carCategoryCheck is null)
                return Result<ExpandoObject>.NotFound(CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForCreation.CarCategoryId!.Value));

            var serviceListCheck = await _repoManager.Service.GetServiceByIdsAsync(packageDtoForCreation.ServiceList!, trackChanges: true);
            if (serviceListCheck.Count() != packageDtoForCreation.ServiceList!.Count())
                return Result<ExpandoObject>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForCreation.ServiceList!));

            var packageWithNameExistCheck = await _repoManager.Package.GetPacakgeByNameAsync(packageDtoForCreation.PackageName!, trackChanges: false);
            if (packageWithNameExistCheck is not null)
                return Result<ExpandoObject>.Conflict(PackageErrors.GetPackageAlreadyExistError(packageDtoForCreation.PackageName!));

            var package = _mapper.Map<Package>(packageDtoForCreation);
            var packageHistory = _mapper.Map<PackageHistory>(packageDtoForCreation);
            var packageConditions = _mapper.Map<IEnumerable<PackageCondition>>(packageDtoForCreation.PackageConditions);

            if (imageTuples is not null)
            {
                var packageImages = new List<PackageImage>();
                foreach (var imageItem in imageTuples)
                {
                    var packageImage = new PackageImage
                    {
                        ImageLink = imageItem.ImageLink,
                        ImageId = imageItem.ImageId
                    };
                    packageImages.Add(packageImage);
                }
                package.PackageImages = packageImages;
            }

            packageHistory.Status = PackageHistoryStatus.Active;
            packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            packageHistory.Services = [.. serviceListCheck];

            package.CarCategory = carCategoryCheck;
            package.PackageHistories.Add(packageHistory);
            package.PackageConditions = [.. packageConditions];
            package.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            package.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();


            await _repoManager.Package.CreateAsync(package);
            await _repoManager.SaveAsync();

            var packageDto = _mapper.Map<PackageDto>(package);

            var packageDtoShaped = _dataShaper.Package.ShapeData(packageDto, fields);

            return Result<ExpandoObject>.Ok(packageDtoShaped);
        }

        public async Task<Result<ExpandoObject>> GetPackageByIdAsync(Guid id, bool trackChanges, string? fields = null)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(id, trackChanges);
            if (package is null)
                return Result<ExpandoObject>.NotFound(PackageErrors.GetPackageNotFoundError(id));

            var packageDto = _mapper.Map<PackageDto>(package);

            var packageDtoShaped = _dataShaper.Package.ShapeData(packageDto, fields);

            return Result<ExpandoObject>.Ok(packageDtoShaped);

        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges)
        {
            var packages = await _repoManager.Package.GetPackagesAsync(packageParameters, trackChanges);

            var packageDto = _mapper.Map<IEnumerable<PackageDto>>(packages);

            var packageDtoShaped = _dataShaper.Package.ShapeData(packageDto, packageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(packageDtoShaped, packages.MetaData);
        }

        public async Task<Result> RemovePacakge(Guid id)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(id, true);
            if (package is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(id));

            _repoManager.Package.Delete(package);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdatePackage(Guid id, PackageDtoForUpdate packageDtoForUpdate)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(id, true);
            if (package is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(id));

            var carCategoryCheck = await _repoManager.CarCategory.GetCarCategoryAsync(packageDtoForUpdate.CarCategoryId!.Value, trackChanges: true);
            if (carCategoryCheck is null)
                return Result.NotFound(CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForUpdate.CarCategoryId!.Value));

            var packageWithNameExistCheck = await _repoManager.Package.GetPacakgeByNameAsync(packageDtoForUpdate.PackageName!, trackChanges: false);
            if (packageWithNameExistCheck is not null && !packageWithNameExistCheck.Id.Equals(id))
                return Result.Conflict(PackageErrors.GetPackageAlreadyExistError(packageDtoForUpdate.PackageName!));

            var packageHistoryForUpdate = _mapper.Map<PackageHistory>(packageDtoForUpdate);
            var currentPackageHistory = package.PackageHistories.FirstOrDefault();

            if (currentPackageHistory is not null &&
                (!currentPackageHistory.PackagePrice.Equals(packageDtoForUpdate.PackagePrice) ||
                !currentPackageHistory.TimeUnit.Equals(packageDtoForUpdate.TimeUnit) ||
                !currentPackageHistory.UsageLimit.Equals(packageDtoForUpdate.UsageLimit) ||
                !currentPackageHistory.ValidityPeriod.Equals(packageDtoForUpdate.ValidityPeriod) ||
                currentPackageHistory.Status.Equals(PackageHistoryStatus.Inactive)
                ))
            {
                currentPackageHistory.Status = PackageHistoryStatus.Inactive;
                var currentPackageHistoryServices = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(currentPackageHistory.Id, true);

                packageHistoryForUpdate.Status = PackageHistoryStatus.Active;
                packageHistoryForUpdate.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
                packageHistoryForUpdate.Services = [.. currentPackageHistoryServices];
                packageHistoryForUpdate.PackageId = id;
                await _repoManager.PackageHistory.CreateAsync(packageHistoryForUpdate);
                package.PackageHistories.Add(packageHistoryForUpdate);
            }
            else if (currentPackageHistory is null)
            {
                return Result.Conflict(PackageErrors.GetPackageDoesNotHaveAnyPackageHistoryError(id));
            }


            _mapper.Map(packageDtoForUpdate, package);
            package.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
