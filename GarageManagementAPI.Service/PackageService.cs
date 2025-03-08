using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using System.Dynamic;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

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
        private async Task<Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>> ValidatePackageInputsForCreate(PackageDtoForCreation packageDtoForCreation)
        {
            var carCategory = await _repoManager.CarCategory.GetCarCategoryAsync(
                packageDtoForCreation.CarCategoryId!.Value,
                trackChanges: false);

            if (carCategory is null)
                return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.NotFound(
                    CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForCreation.CarCategoryId!.Value));

            var services = await _repoManager.Service.GetServiceByIdsAsync(
                packageDtoForCreation.ServiceList!,
                trackChanges: true);

            if (services.Count() != packageDtoForCreation.ServiceList!.Count())
                return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.NotFound(
                    ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForCreation.ServiceList!));

            var existingPackage = await _repoManager.Package.GetPackageByNameAsync(
                packageDtoForCreation.PackageName!,
                trackChanges: false);

            if (existingPackage is not null)
                return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.Conflict(
                    PackageErrors.GetPackageAlreadyExistError(packageDtoForCreation.PackageName!));

            return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.Ok((carCategory, services));
        }

        private async Task<Result<Package>> ValidatePackageInputsForUpdate(Guid packageId, PackageDtoForUpdate packageDtoForUpdate)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, true);
            if (package is null)
                return Result<Package>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var carCategory = await _repoManager.CarCategory.GetCarCategoryAsync(
                packageDtoForUpdate.CarCategoryId!.Value,
                trackChanges: false);

            if (carCategory is null)
                return Result<Package>.NotFound(
                    CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForUpdate.CarCategoryId!.Value));

            var existingPackage = await _repoManager.Package.GetPackageByNameAsync(
                packageDtoForUpdate.PackageName!,
                trackChanges: false);

            if (existingPackage is not null && !existingPackage.Id.Equals(packageId))
                return Result<Package>.Conflict(
                    PackageErrors.GetPackageAlreadyExistError(packageDtoForUpdate.PackageName!));

            return Result<Package>.Ok(package);
        }

        private bool CheckIfPackageHistoryIsChanged(PackageHistory currentPackageHistory, PackageHistory newPackageHistory)
         => !currentPackageHistory.PackagePrice.Equals(newPackageHistory.PackagePrice) ||
            !currentPackageHistory.TimeUnit.Equals(newPackageHistory.TimeUnit) ||
            !currentPackageHistory.UsageLimit.Equals(newPackageHistory.UsageLimit) ||
            !currentPackageHistory.ValidityPeriod.Equals(newPackageHistory.ValidityPeriod);

        private static IEnumerable<PackageImage>? CreatePackageImages(List<(string? imageId, string? imageLink)>? imageTuples, Guid packageId)
        {
            if (imageTuples is null || !imageTuples.Any())
                return null;

            return imageTuples.Select(item => new PackageImage
            {
                PackageId = packageId,
                ImageLink = item.imageLink,
                ImageId = item.imageId
            });
        }

        private async Task SavePackageWithRelatedEntitiesAsync(Package package, PackageHistory packageHistory, IEnumerable<PackageImage>? packageImages)
        {
            await _repoManager.Package.CreateAsync(package);
            await _repoManager.PackageHistory.CreateAsync(package.Id, packageHistory);

            if (packageImages?.Any() == true)
                await _repoManager.PackageImage.CreatesAsync([.. packageImages]);

            await _repoManager.SaveAsync();
        }

        public async Task<Result<ExpandoObject>> CreatePackageAsync(PackageDtoForCreation packageDtoForCreation, List<(string? imageId, string? imageLink)>? imageTuples = null, string? fields = null)
        {
            var validationResult = await ValidatePackageInputsForCreate(packageDtoForCreation);
            if (!validationResult.IsSuccess)
                return validationResult.Failure<ExpandoObject>();

            var category = validationResult.Value.carCategory;
            var services = validationResult.Value.services;

            var package = _mapper.Map<Package>(packageDtoForCreation);
            var packageHistory = _mapper.Map<PackageHistory>(packageDtoForCreation);

            packageHistory.Services = [.. services];
            var packageImages = CreatePackageImages(imageTuples, package.Id);

            await SavePackageWithRelatedEntitiesAsync(
               package,
               packageHistory,
               packageImages);

            var packageDto = _mapper.Map<PackageDto>(package);

            packageDto.Category = category.Category;

            var packageDtoShaped = _dataShaper.Package.ShapeData(packageDto, fields);

            return Result<ExpandoObject>.Ok(packageDtoShaped);
        }


        public async Task<Result<ExpandoObject>> GetPackageByIdAsync(Guid packageId, bool trackChanges, string? fields = null)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges);
            if (package is null)
                return Result<ExpandoObject>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

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

        public async Task<Result> RemovePacakgeAsync(Guid packageId)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, true);
            if (package is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            _repoManager.Package.Delete(package);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdatePackageAsync(Guid packageId, PackageDtoForUpdate packageDtoForUpdate)
        {
            var validationResult = await ValidatePackageInputsForUpdate(packageId, packageDtoForUpdate);
            if (!validationResult.IsSuccess)
                return validationResult;

            var package = validationResult.Value!;
            var currentPackageHistory = package.PackageHistories.FirstOrDefault();

            if (currentPackageHistory is null)
                return Result.Conflict(PackageErrors.GetPackageDoesNotHaveAnyPackageHistoryError(packageId));

            var packageHistoryForUpdate = _mapper.Map<PackageHistory>(packageDtoForUpdate);

            bool shouldCreateNewHistory = CheckIfPackageHistoryIsChanged(currentPackageHistory, packageHistoryForUpdate) || currentPackageHistory.Status.Equals(PackageHistoryStatus.Inactive);

            if (shouldCreateNewHistory)
            {
                await CreateNewPackageHistory(package, currentPackageHistory, packageHistoryForUpdate);
            }

            _mapper.Map(packageDtoForUpdate, package);
            package.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        private async Task CreateNewPackageHistory(Package package, PackageHistory currentPackageHistory, PackageHistory newPackageHistory)
        {
            var currentServices = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(
                currentPackageHistory.Id,
                trackChanges: true);

            newPackageHistory.Services = [.. currentServices];

            await _repoManager.PackageHistory.CreateAsync(package.Id, newPackageHistory);
            _repoManager.PackageHistory.Update(currentPackageHistory);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServiceOfPackageAsync(Guid packageId, ServiceParameters serviceParameters)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (package is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var currentPackageHistory = package.PackageHistories.FirstOrDefault();

            if (currentPackageHistory is null)
                return Result<IEnumerable<ExpandoObject>>.Conflict(PackageErrors.GetPackageDoesNotHaveAnyPackageHistoryError(packageId));

            var services = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(currentPackageHistory!.Id, false, serviceParameters, "CarCategory, CarPart, ServiceImage, ServiceHistories");

            var serviceDto = _mapper.Map<IEnumerable<ServiceDto>>(services);

            var serviceDtoShaped = _dataShaper.Service.ShapeData(serviceDto, serviceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(serviceDtoShaped, services.MetaData);
        }
    }
}
