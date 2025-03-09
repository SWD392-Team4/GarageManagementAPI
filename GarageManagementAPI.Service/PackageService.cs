using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using System.Dynamic;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;

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
                return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.BadRequest(
                    ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForCreation.ServiceList!));

            var existingPackage = await _repoManager.Package.GetPackageByNameAsync(
                packageDtoForCreation.PackageName!,
                trackChanges: false);

            if (existingPackage is not null)
                return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.Conflict(
                    PackageErrors.GetPackageAlreadyExistError(packageDtoForCreation.PackageName!));

            return Result<(CarCategory carCategory, IEnumerable<Entities.Models.Service> services)>.Ok((carCategory, services));
        }



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
            var packageHistory = _mapper.Map<PackageHistory>(package);

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

            var package = validationResult.Value!.package;
            var currentPackageHistory = validationResult.Value!.currentPackageHistory;
            var currentServices = validationResult.Value!.currentServices;

            var isPackageChanged = IsPackageChanged(package, packageDtoForUpdate);
            bool shouldCreateNewHistory =
                (packageDtoForUpdate.AddServices != null && packageDtoForUpdate.AddServices.Any()) ||
                (packageDtoForUpdate.RemoveServices != null && packageDtoForUpdate.RemoveServices.Any());

            if (isPackageChanged)
            {
                _mapper.Map(packageDtoForUpdate, package);
                package.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            }

            if (shouldCreateNewHistory)
            {
                await CreateNewPackageHistory(package, currentPackageHistory, currentServices, packageDtoForUpdate.AddServices, packageDtoForUpdate.RemoveServices);
            }

            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        private async Task<Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>> ValidatePackageInputsForUpdate(Guid packageId, PackageDtoForUpdate packageDtoForUpdate)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, true);
            if (package is null)
                return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var carCategory = await _repoManager.CarCategory.GetCarCategoryAsync(
                packageDtoForUpdate.CarCategoryId!.Value,
                trackChanges: false);
            if (carCategory is null)
                return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.NotFound(
                    CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForUpdate.CarCategoryId!.Value));

            var existingPackage = await _repoManager.Package.GetPackageByNameAsync(
                packageDtoForUpdate.PackageName!,
                trackChanges: false);
            if (existingPackage is not null && !existingPackage.Id.Equals(packageId))
                return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.Conflict(
                    PackageErrors.GetPackageAlreadyExistError(packageDtoForUpdate.PackageName!));

            var currentPackageHistory = await _repoManager.PackageHistory.GetPackageHistoryAsync(package.Id, true);
            var currentServices = new List<Entities.Models.Service>();

            if (currentPackageHistory is not null)
            {
                var services = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(
                    currentPackageHistory.Id,
                    trackChanges: true);

                currentServices.AddRange(services);
            }

            if (packageDtoForUpdate.AddServices != null && packageDtoForUpdate.AddServices.Any())
            {
                var servicesForAdd = await _repoManager.Service.GetServiceByIdsAsync(
                packageDtoForUpdate.AddServices!,
                trackChanges: false);

                if (servicesForAdd.Count() != packageDtoForUpdate.AddServices!.Count())
                    return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.BadRequest(
                        ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForUpdate.AddServices!));

                if (currentServices.Count != 0)
                {
                    var serviceExistInPackage = packageDtoForUpdate.AddServices.Where(id => currentServices.Any(s => s.Id.Equals(id))).FirstOrDefault();
                    if (!serviceExistInPackage.Equals(default))
                        return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.Conflict(
                           PackageErrors.GetServiceAlreadyExistInPackageError(serviceExistInPackage!, packageId));
                }
            }

            if (packageDtoForUpdate.RemoveServices != null && packageDtoForUpdate.RemoveServices.Any())
            {
                var servicesForRemove = await _repoManager.Service.GetServiceByIdsAsync(
                packageDtoForUpdate.RemoveServices!,
                trackChanges: true);

                if (servicesForRemove.Count() != packageDtoForUpdate.RemoveServices!.Count())
                    return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.BadRequest(
                        ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForUpdate.RemoveServices!));

                if (currentServices.Count != 0)
                {
                    var serviceNotExistInPackage = packageDtoForUpdate.RemoveServices.Where(id => !currentServices.Any(s => s.Id.Equals(id))).FirstOrDefault();
                    if (!serviceNotExistInPackage.Equals(default))
                        return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.Conflict(
                       PackageErrors.GetServiceNotExistInPackage(serviceNotExistInPackage!, packageId));
                }

            }


            return Result<(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices)>.Ok((package, currentPackageHistory, currentServices));
        }

        private bool IsPackageChanged(Package originalPackage, PackageDtoForUpdate updateDto)
        {
            return (updateDto.ServiceCategory.HasValue && originalPackage.ServiceCategory != updateDto.ServiceCategory.Value) ||
                   (updateDto.CarCategoryId.HasValue && originalPackage.CarCategoryId != updateDto.CarCategoryId.Value) ||
                   (updateDto.PackageName != null && !string.Equals(originalPackage.PackageName, updateDto.PackageName, StringComparison.OrdinalIgnoreCase)) ||
                   (updateDto.Description != null && !string.Equals(originalPackage.Description?.Trim(), updateDto.Description?.Trim(), StringComparison.OrdinalIgnoreCase)) ||
                   (updateDto.Type.HasValue && originalPackage.Type != updateDto.Type.Value) ||
                   (updateDto.PackagePrice.HasValue && originalPackage.PackagePrice != updateDto.PackagePrice.Value) ||
                   (updateDto.ValidityPeriod.HasValue && originalPackage.ValidityPeriod != updateDto.ValidityPeriod.Value) ||
                   (updateDto.TimeUnit.HasValue && originalPackage.TimeUnit != updateDto.TimeUnit.Value) ||
                   (updateDto.UsageLimit.HasValue && originalPackage.UsageLimit != updateDto.UsageLimit.Value) ||
                   (updateDto.Status.HasValue && originalPackage.Status != updateDto.Status.Value);
        }

        private async Task CreateNewPackageHistory(Package package, PackageHistory? currentPackageHistory, List<Entities.Models.Service> currentServices, Guid[]? addServices, Guid[]? removeServices)
        {
            var newPackageHistory = _mapper.Map<PackageHistory>(package);

            if (currentPackageHistory is not null)
            {
                var services = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(
                    currentPackageHistory.Id,
                    trackChanges: true);

                currentServices.AddRange(services);
            }

            if (addServices != null && addServices.Any())
            {
                var servicesForAdd = await _repoManager.Service.GetServiceByIdsAsync(
                addServices,
                trackChanges: true);

                currentServices.AddRange(servicesForAdd);
            }

            if (removeServices != null && removeServices.Any())
            {
                var servicesForRemove = await _repoManager.Service.GetServiceByIdsAsync(
                    removeServices,
                    trackChanges: true);

                currentServices = [.. currentServices.Except(servicesForRemove)];
            }

            newPackageHistory.Services = [.. currentServices];

            await _repoManager.PackageHistory.CreateAsync(package.Id, newPackageHistory);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServiceOfPackageAsync(Guid packageId, ServiceParameters serviceParameters)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (package is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var currentPackageHistory = await _repoManager.PackageHistory.GetPackageHistoryAsync(package.Id, true);

            if (currentPackageHistory is null)
                return Result<IEnumerable<ExpandoObject>>.Conflict(PackageErrors.GetPackageDoesNotHaveAnyPackageHistoryError(packageId));

            var services = await _repoManager.Service.GetServiceByPackageHistoryIdAsync(currentPackageHistory!.Id, false, serviceParameters, "CarCategory, CarPart, ServiceImage, ServiceHistories");

            var serviceDto = _mapper.Map<IEnumerable<ServiceDto>>(services);

            var serviceDtoShaped = _dataShaper.Service.ShapeData(serviceDto, serviceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(serviceDtoShaped, services.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetHistoriesOfPackageAsync(Guid packageId, PackageHistoryParameters packageHistoryParameters, bool trackChanges)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (package is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageHistories = await _repoManager.PackageHistory.GetPackageHistoriesAsync(packageId, packageHistoryParameters, false);

            var packageHistoryDto = _mapper.Map<IEnumerable<PackageHistoryDto>>(packageHistories);

            var packageHistoryDtoShaped = _dataShaper.PackageHistory.ShapeData(packageHistoryDto, packageHistoryParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(packageHistoryDtoShaped, packageHistories.MetaData);
        }
    }
}
