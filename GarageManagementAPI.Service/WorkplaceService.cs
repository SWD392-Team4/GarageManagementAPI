using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Utilities;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public WorkplaceService(
            IRepositoryManager repository,
            IMapper mapper,
            IDataShaperManager dataShaperManager)
        {
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaperManager;
        }

        private async Task<Result<Workplace>> GetAndCheckIfWorkplaceExist(Guid workplaceId, bool trackChanges)
        {
            var workplace = await _repository.Workplace.GetWorkplace(workplaceId, trackChanges);
            if (workplace == null)
                return workplace.NotFound(workplaceId);

            return workplace.OkResult();
        }

        private async Task<bool> CheckIfWorkPlaceExistByNameAndFullAddressAndPhoneNumber(WorkplaceDtoForCreation workplaceDtoForCreation)
        {
            var address = workplaceDtoForCreation.Address!.Trim();
            var province = workplaceDtoForCreation.Province!.Trim();
            var district = workplaceDtoForCreation.District!.Trim();
            var ward = workplaceDtoForCreation.Ward!.Trim();
            var phoneNumber = workplaceDtoForCreation.PhoneNumber!.Trim();
            var name = workplaceDtoForCreation.Name!.Trim();

            var exists = await _repository.Workplace.FindByCondition(x =>
                (x.Address.Trim().Equals(address) &&
                 x.Province.Trim().Equals(province) &&
                 x.District.Trim().Equals(district) &&
                 x.Ward.Trim().Equals(ward)) ||
                x.PhoneNumber.Trim().Equals(phoneNumber) ||
                x.Name.Trim().Equals(name),
                false).AnyAsync();

            return exists;
        }

        public async Task<Result<WorkplaceDto>> CreateWorkplace(WorkplaceDtoForCreation workplaceDtoForCreation)
        {
            var check = await CheckIfWorkPlaceExistByNameAndFullAddressAndPhoneNumber(workplaceDtoForCreation);
            if (check)
                return Result<WorkplaceDto>.BadRequest([WorkplaceErros.GetWorkplaceAlreadyExistError(workplaceDtoForCreation)]);

            var workplaceEntity = _mapper.Map<Workplace>(workplaceDtoForCreation);

            workplaceEntity.CreatedAt = DateTimeHelper.SEAsiaStandardTime();
            workplaceEntity.UpdatedAt = DateTimeHelper.SEAsiaStandardTime();
            workplaceEntity.Status = WorkplaceStatus.PendingActivation;

            await _repository.Workplace.CreateWorkplaceAsync(workplaceEntity);
            await _repository.SaveAsync();

            var workplaceDtoToReturn = _mapper.Map<WorkplaceDto>(workplaceEntity);

            return workplaceDtoToReturn.CreatedResult();
        }

        public async Task<Result<ExpandoObject>> GetWorkplace(Guid workplaceId, WorkplaceParameters workplaceParameters, bool trackChanges)
        {
            var workplaceResult = await GetAndCheckIfWorkplaceExist(workplaceId, trackChanges);
            if (!workplaceResult.IsSuccess)
                return Result<ExpandoObject>.Failure(workplaceResult.StatusCode, workplaceResult.Errors!);

            var workplaceEntity = workplaceResult.GetValue<Workplace>();

            var workplaceDto = _mapper.Map<WorkplaceDto>(workplaceEntity);

            var workplaceShaper = _dataShaper.Workplace.ShapeData(workplaceDto, workplaceParameters.Fields);

            return workplaceShaper;
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetWorkplaces(WorkplaceParameters workplaceParameters, bool trackChanges)
        {
            var workplacesWithMetadata = await _repository.Workplace.GetWorkplaces(workplaceParameters, trackChanges);

            var workplacesDto = _mapper.Map<IEnumerable<WorkplaceDto>>(workplacesWithMetadata);

            var workplaceShaper = _dataShaper.Workplace.ShapeData(workplacesDto, workplaceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(workplaceShaper, workplacesWithMetadata.MetaData);
        }

        public async Task<Result> UpdateWorkplace(Guid workplaceId, WorkplaceDtoForUpdate workplaceDtoForUpdate, bool trackChanges)
        {
            var workplaceResult = await GetAndCheckIfWorkplaceExist(workplaceId, trackChanges);
            if (!workplaceResult.IsSuccess)
                return Result<WorkplaceDto>.Failure(workplaceResult.StatusCode, workplaceResult.Errors!);

            var workplaceEntity = workplaceResult.GetValue<Workplace>();

            _mapper.Map(workplaceDtoForUpdate, workplaceEntity);

            workplaceEntity.UpdatedAt = DateTimeHelper.SEAsiaStandardTime();
            await _repository.SaveAsync();

            return Result.NoContent();
        }

        public async Task<Result<WorkplaceDtoForUpdate>> GetWorkplaceForPartiallyUpdate(Guid workplaceId, bool trackChanges)
        {
            var workplaceResult = await GetAndCheckIfWorkplaceExist(workplaceId, trackChanges);
            if (!workplaceResult.IsSuccess)
                return Result<WorkplaceDtoForUpdate>.Failure(workplaceResult.StatusCode, workplaceResult.Errors!);

            var workplaceEntity = workplaceResult.GetValue<Workplace>();

            var workplaceDtoForUpdate = _mapper.Map<WorkplaceDtoForUpdate>(workplaceEntity);

            return workplaceDtoForUpdate;
        }
    }
}
