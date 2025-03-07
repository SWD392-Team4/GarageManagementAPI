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

            var packageConditionOfPackageExist  = await _repoManager.PackageCondition
                .GetPackageConditionAsync(packageId, false, packageConditionDtoForCreation.ConditionType, packageConditionDtoForCreation.ConditionValue);
            if(packageConditionOfPackageExist is not null)
                return Result<PackageConditionDto>.Conflict(PackageConditionErrors.GetPackageConditionExistError(packageId, packageConditionDtoForCreation.ConditionType, packageConditionDtoForCreation.ConditionValue));

            var packageCondtionEntity = _mapper.Map<PackageCondition>(packageConditionDtoForCreation);

            await _repoManager.PackageCondition.CreateAsync(packageId, packageCondtionEntity);

            var packageCondtionDto = _mapper.Map<PackageConditionDto>(packageCondtionEntity);

            return Result<PackageConditionDto>.Ok(packageCondtionDto);

        }

        public async Task<Result<ExpandoObject>> GetPackageConditionAsync(Guid packageId, Guid packageConditionId, bool trackChanges, string? fields = null)
        {
            var packageExistCheck = await _repoManager.Package.GetPackageByIdAsync(packageId, false);
            if (packageExistCheck is null)
                return Result<ExpandoObject>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageCondition = await _repoManager.PackageCondition.GetPackageConditionAsync(packageId, packageConditionId, trackChanges);
            if (packageCondition is null)
                return Result<ExpandoObject>.NotFound(PackageConditionErrors.GetPackageConditionNotFoundError(packageId, packageConditionId));

            var packageConditionDto = _mapper.Map<PackageConditionDto>(packageCondition);
            var packageConditionShaped = _dataShaper.PackageCondition.ShapeData(packageConditionDto, fields);

            return Result<ExpandoObject>.Ok(packageConditionShaped);
        }

        public Task<Result<IEnumerable<ExpandoObject>>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemovePackageConditionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdatePackageConditionAsync(Guid id, PackageConditionDtoForUpdate packageConditionDtoForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
