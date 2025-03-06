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

        public async Task<Result<PackageDto>> CreatePackage(PackageDtoForCreation packageDtoForCreation, List<(string? publicId, string? absoluteUrl)>? imageTuples = null)
        {
            var checkIfPackgeExist = await _repoManager.Package.GetPacakgeByNameAsync(packageDtoForCreation.PackageName!, false);

            if (checkIfPackgeExist is not null)
                return Result<PackageDto>.BadRequest(PackageErrors.GetPackageAlreadyExistError(packageDtoForCreation.PackageName!));

            var checkIfCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(packageDtoForCreation.CarCategoryId!.Value, false);
            if (checkIfCarCategoryExist is null)
                return Result<PackageDto>.NotFound(CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForCreation.CarCategoryId.Value));

            var packageEntity = _mapper.Map<Package>(packageDtoForCreation);
            var packageHistory = _mapper.Map<PackageHistory>(packageDtoForCreation);

            packageHistory.Status = PackageHistoryStatus.Active;
            packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            if (packageDtoForCreation.ServiceList is not null && packageDtoForCreation.ServiceList.Any())
            {
                var serviceList = await _repoManager.Service.GetByIdsAsync(packageDtoForCreation.ServiceList!, true);
                if (!serviceList.Any())
                    return Result<PackageDto>.NotFound(ServiceErrors.GetServiceNotFoundWithIdError(packageDtoForCreation.ServiceList!.ToList()));

                if (serviceList.Count() != packageDtoForCreation.ServiceList!.Count())
                    return Result<PackageDto>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(packageDtoForCreation.ServiceList!.ToList()));
                var services = packageHistory.Services.ToList();
                services.AddRange(serviceList);
                packageHistory.Services = services;
            }

            if (imageTuples != null && imageTuples.Any())
            {
                packageEntity.PackageImages = [.. imageTuples.Select(imageTuple => new PackageImage
                {
                    ImageId = imageTuple.publicId,
                    ImageLink = imageTuple.absoluteUrl
                })];
            }
            packageEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            packageEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            packageEntity.Status = PackageStatus.Active;

            packageEntity.PackageHistories.Add(packageHistory);
            await _repoManager.Package.CreateAsync(packageEntity);
            await _repoManager.SaveAsync();
            packageEntity.CarCategory = checkIfCarCategoryExist;

            var packageDtoToReturn = _mapper.Map<PackageDto>(packageEntity);

            return Result<PackageDto>.Created(packageDtoToReturn);
        }

        public async Task<Result<PackageDto>> GetPackageByIdAsync(Guid id, bool trackChanges)
        {
            var checkIfPackageExist = await _repoManager.Package.GetPackageByIdAsync(id, false);

            if (checkIfPackageExist is null)
                return Result<PackageDto>.NotFound(PackageErrors.GetPackageNotFoundError(id));

            var packageDto = _mapper.Map<PackageDto>(checkIfPackageExist);

            return Result<PackageDto>.Ok(packageDto);

        }

        public async Task<Result<IEnumerable<PackageDto>>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges)
        {
            var packages = await _repoManager.Package.GetPackagesAsync(packageParameters, trackChanges);

            var packageDtos = _mapper.Map<IEnumerable<PackageDto>>(packages);

            return Result<IEnumerable<PackageDto>>.Ok(packageDtos, packages.MetaData);
        }

        public Task<Result> RemovePacakge(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> UpdatePackage(Guid id, PackageDtoForUpdate packageDtoForUpdate, List<(string? publicId, string? absoluteUrl)>? imageTuples = null)
        {
            var checkIfPackageExist = await _repoManager.Package.GetPackageByIdAsync(id, true);
            if (checkIfPackageExist is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(id));

            var checkIfPackageExistWithName = await _repoManager.Package.GetPacakgeByNameAsync(packageDtoForUpdate.PackageName!, false);

            if (checkIfPackageExistWithName is not null && !checkIfPackageExistWithName.Id.Equals(id))
                return Result<PackageDto>.BadRequest(PackageErrors.GetPackageAlreadyExistError(packageDtoForUpdate.PackageName!));

            var checkIfCarCategoryExist = await _repoManager.CarCategory.GetCarCategoryAsync(packageDtoForUpdate.CarCategoryId!.Value, false);
            if (checkIfCarCategoryExist is null)
                return Result<PackageDto>.NotFound(CarCategoryErrors.GetCarCategoryNotFoundError(packageDtoForUpdate.CarCategoryId.Value));

            _mapper.Map(packageDtoForUpdate, checkIfPackageExist);

            var recentPackageHistory = checkIfPackageExist.PackageHistories.FirstOrDefault();
            var serviceListId = packageDtoForUpdate.ServiceList;

            if (recentPackageHistory is not null && serviceListId is not null && serviceListId.Any() && recentPackageHistory!.Services is not null)
            {
                //recentPackageHistory = await _repoManager.PackageHistory.GetPackageHistoryByIdAsync(recentPackageHistory.Id, true);
                var recentServiceListId = recentPackageHistory!.Services.Select(e => e.Id);

                if (((serviceListId.Except(recentServiceListId).Any() || recentServiceListId.Except(serviceListId).Any()) ||
                        (!recentPackageHistory.PackagePrice.Equals(packageDtoForUpdate.PackagePrice) ||
                         !recentPackageHistory.ValidityPeriod.Equals(packageDtoForUpdate.ValidityPeriod) ||
                         !recentPackageHistory.TimeUnit.Equals(packageDtoForUpdate.TimeUnit) ||
                         !recentPackageHistory.UsageLimit.Equals(packageDtoForUpdate.UsageLimit))
                    ))
                {
                    var packageHistory = _mapper.Map<PackageHistory>(packageDtoForUpdate);
                    packageHistory.Status = PackageHistoryStatus.Active;
                    packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
                    recentPackageHistory.Status = PackageHistoryStatus.Inactive;

                    var serviceList = await _repoManager.Service.GetByIdsAsync(serviceListId, true);
                    if (!serviceList.Any())
                        return Result<PackageDto>.NotFound(ServiceErrors.GetServiceNotFoundWithIdError(serviceListId));

                    if (serviceList.Count() != serviceListId.Count())
                        return Result<PackageDto>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(serviceListId));
                    var services = packageHistory.Services.ToList();
                    services.AddRange(serviceList);
                    packageHistory.Services = services;
                    packageHistory.PackageId = checkIfPackageExist.Id;
                    await _repoManager.PackageHistory.CreateAsync(packageHistory);
                    checkIfPackageExist.PackageHistories.Add(packageHistory);
                }
            }
            else if (recentPackageHistory is null && serviceListId is not null && serviceListId.Any())
            {
                var packageHistory = _mapper.Map<PackageHistory>(packageDtoForUpdate);
                packageHistory.Status = PackageHistoryStatus.Active;
                packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

                var serviceList = await _repoManager.Service.GetByIdsAsync(serviceListId, true);
                if (!serviceList.Any())
                    return Result<PackageDto>.NotFound(ServiceErrors.GetServiceNotFoundWithIdError(serviceListId));

                if (serviceList.Count() != serviceListId.Count())
                    return Result<PackageDto>.NotFound(ServiceErrors.GetServicesFoundNotMatchWithIdsError(serviceListId));
                var services = packageHistory.Services.ToList();
                services.AddRange(serviceList);
                packageHistory.Services = services;
                packageHistory.PackageId = checkIfPackageExist.Id;
                await _repoManager.PackageHistory.CreateAsync(packageHistory);
                checkIfPackageExist.PackageHistories.Add(packageHistory);
            }
            //if (packageDtoForUpdate.PackageConditionsForUpdate is not null && packageDtoForUpdate.PackageConditionsForUpdate.Any())
            //{
            //    var packageConditions = await _repoManager.PackageCondition.GetPackageConditionsByPackageIdAsync(id, true);

            //    _mapper.Map(packageDtoForUpdate.PackageConditionsForUpdate, packageConditions);
            //}

            checkIfPackageExist.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }
    }
}
