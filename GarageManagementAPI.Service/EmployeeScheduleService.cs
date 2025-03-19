using AutoMapper;

using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Service
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public EmployeeScheduleService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result> EndEmployeeScheduleAsync(Guid scheduleId)
        {
            var schedule = await _repoManager.EmployeeSchedule.FindByCondition(s => s.Id.Equals(scheduleId), true).FirstOrDefaultAsync();
            if (schedule == null)
            {
                return Result.NotFound(UserErrors.GetEmployeeScheduleNotFoundWithIdError(scheduleId));
            }

            schedule.Status = EmployeeScheduleStatus.Completed;
            schedule.ActualEndTime = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            _repoManager.EmployeeSchedule.Update(schedule);
            await _repoManager.SaveAsync();

            return Result.Ok();

        }

        public async Task<Result<IEnumerable<EmployeeScheduleDtoWithRelation>>> GetEmployeeSchedulesAsync(Guid userId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, trackChanges, "EmployeeInfo");
            if (user == null)
            {
                return Result<IEnumerable<EmployeeScheduleDtoWithRelation>>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));
            }

            var employeeSchedule = await _repoManager.EmployeeSchedule.GetEmployeeSchedulesOfEmployeeAsync(user.EmployeeInfo.WorkplaceId.Value, userId, employeeScheduleParameters, trackChanges);

            var employeeScheduleDto = _mapper.Map<IEnumerable<EmployeeScheduleDtoWithRelation>>(employeeSchedule);

            return Result<IEnumerable<EmployeeScheduleDtoWithRelation>>.Ok(employeeScheduleDto, employeeSchedule.MetaData);
        }

        public async Task<Result> StartEmployeeScheduleAsync(Guid scheduleId, EmployeeScheduleDtoForStart employeeScheduleDtoForStart)
        {
            var schedule = await _repoManager.EmployeeSchedule.FindByCondition(s => s.Id.Equals(scheduleId), true).FirstOrDefaultAsync();
            if (schedule == null)
            {
                return Result.NotFound(UserErrors.GetEmployeeScheduleNotFoundWithIdError(scheduleId));
            }

            schedule.Status = EmployeeScheduleStatus.InProgress;
            schedule.EstimatedEndTime = employeeScheduleDtoForStart.EstimatedEndTime;
            schedule.StartTime = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            _repoManager.EmployeeSchedule.Update(schedule);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }
    }
}
