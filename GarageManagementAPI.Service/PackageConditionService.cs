using AutoMapper;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using GarageManagementAPI.Shared.ErrorsConstant.PackageCondition;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class PackageConditionService : IPackageConditionService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public PackageConditionService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<PackageConditionDto>> CreatePackageConditionAsync(Guid packageId, PackageConditionDtoForCreation packageConditionDtoForCreation)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result<PackageConditionDto>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageConditionOfPackageExist = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, false, packageConditionDtoForCreation.ConditionType, packageConditionDtoForCreation.ConditionValue);
            if (packageConditionOfPackageExist is not null)
                return Result<PackageConditionDto>.Conflict(PackageConditionErrors.GetPackageConditionExistError(packageId, packageConditionDtoForCreation.ConditionType, packageConditionDtoForCreation.ConditionValue));

            var packageCondtionEntity = _mapper.Map<PackageCondition>(packageConditionDtoForCreation);

            await _repoManager.PackageCondition.CreateAsync(packageId, packageCondtionEntity);
            await _repoManager.SaveAsync();

            var packageCondtionDto = _mapper.Map<PackageConditionDto>(packageCondtionEntity);

            return Result<PackageConditionDto>.Ok(packageCondtionDto);

        }

        public async Task<Result<ExpandoObject>> GetPackageConditionAsync(Guid packageId, Guid packageConditionId, string? fields = null)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result<ExpandoObject>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageCondition = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, packageConditionId, false);
            if (packageCondition is null)
                return Result<ExpandoObject>.NotFound(PackageConditionErrors.GetPackageConditionNotFoundError(packageId, packageConditionId));

            var packageConditionDto = _mapper.Map<PackageConditionDto>(packageCondition);
            var packageConditionShaped = _dataShaper.PackageCondition.ShapeData(packageConditionDto, fields);

            return Result<ExpandoObject>.Ok(packageConditionShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters)
        {
            if (packageConditionParameters.ValidConditionValueRange is false)
                return Result<IEnumerable<ExpandoObject>>.BadRequest(PackageConditionErrors.GetPackageMinConditionValueGreaterThanMaxConditionValueError());

            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageConditions = await _repoManager.PackageCondition.GetPackageConditionsAsync(packageId, packageConditionParameters, false);

            var pacakgeConditionsDto = _mapper.Map<IEnumerable<PackageConditionDto>>(packageConditions);

            var packageConditionsShaped = _dataShaper.PackageCondition.ShapeData(pacakgeConditionsDto, packageConditionParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(packageConditionsShaped);
        }

        public async Task<Result> RemovePackageConditionAsync(Guid packageId, Guid packageConditionId)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageCondition = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, packageConditionId, true);
            if (packageCondition is null)
                return Result.NotFound(PackageConditionErrors.GetPackageConditionNotFoundError(packageId, packageConditionId));

            _repoManager.PackageCondition.Delete(packageCondition);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> RemovePackageConditionAsync(Guid packageId)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageConditions = await _repoManager.PackageCondition.GetPackageConditionsAsync(packageId, true);
            if (!packageConditions.Any())
                return Result.NotFound(PackageConditionErrors.GetPackageConditionOfPackageNotFoundError(packageId));

            _repoManager.PackageCondition.Deletes([.. packageConditions]);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdatePackageConditionAsync(Guid packageId, Guid packageConditionId, PackageConditionDtoForUpdate packageConditionDtoForUpdate)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageCondition = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, packageConditionId, true);
            if (packageCondition is null)
                return Result.NotFound(PackageConditionErrors.GetPackageConditionNotFoundError(packageId, packageConditionId));

            var packageConditionOfPackageExist = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, false, packageConditionDtoForUpdate.ConditionType, packageConditionDtoForUpdate.ConditionValue);
            if (packageConditionOfPackageExist is not null)
                return Result<PackageConditionDto>.Conflict(PackageConditionErrors.GetPackageConditionExistError(packageId, packageConditionDtoForUpdate.ConditionType, packageConditionDtoForUpdate.ConditionValue));


            _mapper.Map(packageConditionDtoForUpdate, packageCondition);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
