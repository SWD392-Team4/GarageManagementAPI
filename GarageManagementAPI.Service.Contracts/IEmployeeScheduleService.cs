using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IEmployeeScheduleService
    {
        Task<Result<IEnumerable<EmployeeScheduleDtoWithRelation>>> GetEmployeeSchedulesAsync(Guid userId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges);

        Task<Result> StartEmployeeScheduleAsync(Guid scheduleId, EmployeeScheduleDtoForStart employeeScheduleDtoForStart);

        Task<Result> EndEmployeeScheduleAsync(Guid scheduleId);
    }
}
