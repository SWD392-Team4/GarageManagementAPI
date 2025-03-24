using AutoMapper;

using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
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
        private readonly IMailService _mailService;

        public EmployeeScheduleService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper, IMailService mailService)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
            _mailService = mailService;
        }

        public async Task<Result> EndEmployeeScheduleAsync(Guid scheduleId)
        {
            // Lấy booking hiện tại
            var schedule = await _repoManager.EmployeeSchedule
                                 .FindByCondition(s => s.Id.Equals(scheduleId), true)
                                  .Include(s => s.AppointmentDetail)
                                  .ThenInclude(ad => ad.ServiceHistory)
                                  .ThenInclude(sh => sh.Service)
                                  .Include(s => s.AppointmentDetail)
                                  .ThenInclude(s => s.Appointment)
                                  .ThenInclude(a => a.AppointmentDetails)
                                    .Include(s => s.AppointmentDetail)
                                  .ThenInclude(s => s.Appointment)
                                  .ThenInclude(a => a.AppointmentDetailPackages)
                                   .Include(s => s.AppointmentDetail)
                                   .ThenInclude(s => s.AppointmentReplacementParts)
                                  .FirstOrDefaultAsync();
            if (schedule == null)
            {
                return Result.NotFound(UserErrors.GetEmployeeScheduleNotFoundWithIdError(scheduleId));
            }

            if (schedule.Status == EmployeeScheduleStatus.Completed)
            {
                return Result.BadRequest(AppointmentErrors.GetEmployeeScheduleAlreadyCompletedError(scheduleId));
            }


            // Lấy thời gian hiện tại theo múi giờ SEAsiaStandardTime
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            schedule.ActualEndTime = now;
            schedule.Status = EmployeeScheduleStatus.Completed;
            schedule.AppointmentDetail.Status = AppointmentDetailStatus.Completed;
            if (schedule.AppointmentDetail.AppointmentReplacementParts != null)
            {
                foreach (var appointmentReplacementPart in schedule.AppointmentDetail.AppointmentReplacementParts)
                {
                    appointmentReplacementPart.Status = AppointmentReplacementPartStatus.Completed;
                    _repoManager.AppointmentReplacementPart.Update(appointmentReplacementPart);
                }
            }
            if (schedule.AppointmentDetail.PackageHistoryId != null)
            {
                var appointmentDetailPackage = schedule.AppointmentDetail.Appointment.AppointmentDetailPackages.Where(adp => adp.PackageHistoryId.Equals(schedule.AppointmentDetail.PackageHistoryId)).FirstOrDefault();
                var checkPackageCompleted = true;
                foreach (var appointmentDetail in schedule.AppointmentDetail.Appointment.AppointmentDetails)
                {
                    if (appointmentDetail.Status != AppointmentDetailStatus.Completed && appointmentDetail.PackageHistoryId.Equals(schedule.AppointmentDetail.PackageHistoryId))
                    {
                        checkPackageCompleted = false;
                        break;
                    }
                }

                if (checkPackageCompleted)
                {
                    appointmentDetailPackage.Status = AppointmentDetailPackageStatus.Completed;
                    _repoManager.AppointmentDetailPackage.Update(appointmentDetailPackage);
                }
            }


            // Tính delta: sự chênh lệch giữa thời gian kết thúc thực tế và dự kiến
            TimeSpan delta = now - schedule.EstimatedEndTime.Value;

            // Cập nhật booking hiện tại
            _repoManager.EmployeeSchedule.Update(schedule);

            // Giả sử giờ hành chính từ 8:00 đến 18:00
            TimeSpan businessStart = TimeSpan.FromHours(8);
            TimeSpan businessEnd = TimeSpan.FromHours(18);

            // Lấy các booking sau của nhân viên chưa bắt đầu
            var subsequentSchedules = await _repoManager.EmployeeSchedule.GetSubsequentSchedules(
                                          schedule.EmployeeId, schedule.Id, true);

            foreach (var subsequent in subsequentSchedules)
            {
                // Cập nhật EstimatedEndTime cho booking sau bằng cách cộng thêm delta
                subsequent.EstimatedEndTime = subsequent.EstimatedEndTime.Value.Add(delta);

                // Nếu sau khi điều chỉnh, EstimatedEndTime vượt quá giờ hành chính của ngày đó, chuyển booking sang ngày hôm sau
                if (subsequent.EstimatedEndTime.Value.TimeOfDay > businessEnd)
                {
                    // Đặt lại thời điểm bắt đầu của ngày mới: ngày sau với giờ bắt đầu là businessStart (8:00 sáng)
                    var newStart = subsequent.EstimatedEndTime.Value.Date.AddDays(1).Add(businessStart);
                    // Giả sử thời lượng của booking không đổi
                    double duration = subsequent.AppointmentDetail.ServiceHistory.Service.EstimatedHours;
                    subsequent.EstimatedEndTime = newStart.AddHours(duration);
                }

                _repoManager.EmployeeSchedule.Update(subsequent);
            }


            var isAllDetailCompleted = true;
            var isAllPackagesCompleted = true;

            foreach (var appointmentDetail in schedule.AppointmentDetail.Appointment.AppointmentDetails)
            {
                if (appointmentDetail.Status != AppointmentDetailStatus.Completed)
                {
                    isAllDetailCompleted = false;
                    break;
                }
            }

            foreach (var appointmentDetailPackage in schedule.AppointmentDetail.Appointment.AppointmentDetailPackages)
            {
                if (appointmentDetailPackage.Status != AppointmentDetailPackageStatus.Completed)
                {
                    isAllPackagesCompleted = false;
                    break;
                }
            }

            if (isAllDetailCompleted && isAllPackagesCompleted)
            {
                schedule.AppointmentDetail.Appointment.Status = AppointmentStatus.Completed;
                _repoManager.Appointment.Update(schedule.AppointmentDetail.Appointment);
                await _mailService.SendFinishAppointment(schedule.AppointmentDetail.Appointment.Id);
            }

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

        public async Task<Result<IEnumerable<AppointmentDto>>> GetEmployeeScheduleAsync(Guid userId, AppointmentParameters appointmentParameters, bool trackChanges)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, trackChanges, "EmployeeInfo");
            if (user == null || user.EmployeeInfo == null)
            {
                return Result<IEnumerable<AppointmentDto>>.NotFound(UserErrors.GetUserNotFoundWithIdError(userId));
            }
            var employeeSchedule = await _repoManager.Appointment.GetAppointmentsOfEmployeeAsync(user.EmployeeInfo.WorkplaceId.Value, userId, appointmentParameters, trackChanges);

            var appointmentDto = _mapper.Map<IEnumerable<AppointmentDto>>(employeeSchedule);

            return Result<IEnumerable<AppointmentDto>>.Ok(appointmentDto, employeeSchedule.MetaData);

        }



        public async Task<Result> StartEmployeeScheduleAsync(Guid scheduleId)
        {
            // Lấy booking hiện tại theo scheduleId
            var schedule = await _repoManager.EmployeeSchedule
                              .FindByCondition(s => s.Id.Equals(scheduleId), true)
                              .Include(s => s.AppointmentDetail)
                              .ThenInclude(ad => ad.ServiceHistory)
                              .ThenInclude(sh => sh.Service)
                              .Include(s => s.AppointmentDetail)
                              .ThenInclude(s => s.Appointment)
                              .ThenInclude(a => a.AppointmentDetailPackages)
                              .FirstOrDefaultAsync();
            if (schedule == null)
            {
                return Result.NotFound(UserErrors.GetEmployeeScheduleNotFoundWithIdError(scheduleId));
            }

            if (schedule.Status == EmployeeScheduleStatus.Completed)
            {
                return Result.BadRequest(AppointmentErrors.GetEmployeeScheduleAlreadyCompletedError(scheduleId));
            }

            if (schedule.Status == EmployeeScheduleStatus.InProgress)
            {
                return Result.BadRequest(AppointmentErrors.GetEmployeeScheduleAlreadyStartError(scheduleId));
            }

            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            // Kiểm tra nếu nhân viên đã có appointment khác đang InProgress hoặc đang nằm trong khoảng thời gian hoạt động của appointment khác
            if (await _repoManager.EmployeeSchedule.HasOverlappingInProgressOrActiveSchedule(schedule.EmployeeId, now, false))
            {
                return Result.Conflict(AppointmentErrors.GetEmployeeHasOverlappingSchedules(schedule.EmployeeId));
            }

            // Cập nhật trạng thái và thời gian bắt đầu thực tế
            schedule.Status = EmployeeScheduleStatus.InProgress;
            var actualStartTime = now;
            schedule.StartTime = actualStartTime;
            if (schedule.AppointmentDetail.Status != AppointmentDetailStatus.InProgress)
            {
                schedule.AppointmentDetail.Status = AppointmentDetailStatus.InProgress;
                _repoManager.AppointmentDetail.Update(schedule.AppointmentDetail);
            }

            if (schedule.AppointmentDetail.Appointment.Status != AppointmentStatus.InProgress)
            {
                schedule.AppointmentDetail.Appointment.Status = AppointmentStatus.InProgress;
                _repoManager.Appointment.Update(schedule.AppointmentDetail.Appointment);
            }


            // Lấy thời lượng ước tính của dịch vụ
            double serviceDurationHours = schedule.AppointmentDetail.ServiceHistory.Service.EstimatedHours;

            // Tính EstimatedEndTime mới dựa trên thời gian bắt đầu thực tế
            var newEstimatedEndTime = actualStartTime.AddHours(serviceDurationHours);

            // Tính delta (sự chênh lệch giữa EstimatedEndTime mới và EstimatedEndTime ban đầu)
            var delta = newEstimatedEndTime - schedule.EstimatedEndTime;

            // Cập nhật EstimatedEndTime cho booking hiện tại
            schedule.EstimatedEndTime = newEstimatedEndTime;

            // Giả sử giờ hành chính từ 8:00 đến 18:00
            TimeSpan businessStart = TimeSpan.FromHours(8);
            TimeSpan businessEnd = TimeSpan.FromHours(18);

            // Lấy các booking sau của nhân viên (chưa start) – bạn cần implement phương thức này để lấy danh sách theo thứ tự
            var subsequentSchedules = await _repoManager.EmployeeSchedule.GetSubsequentSchedules(
                                          schedule.EmployeeId, schedule.Id, true);
            // Ví dụ: GetSubsequentSchedules có thể lấy các booking có EstimatedEndTime ban đầu lớn hơn booking hiện tại

            // Cập nhật lại thời gian cho các booking sau
            foreach (var subsequent in subsequentSchedules)
            {
                // Cập nhật EstimatedEndTime bằng cách cộng thêm delta
                subsequent.EstimatedEndTime = subsequent.EstimatedEndTime.Value.Add(delta.Value);

                // Nếu sau khi cập nhật, EstimatedEndTime vượt quá giờ hành chính của ngày đó,
                // chuyển sang ngày hôm sau với giờ bắt đầu là businessStart
                if (subsequent.EstimatedEndTime.Value.TimeOfDay > businessEnd)
                {
                    // Lấy ngày hôm sau, bắt đầu từ businessStart (ví dụ 8:00 sáng)
                    var newStart = subsequent.EstimatedEndTime.Value.Date.AddDays(1).Add(businessStart);
                    // Giả sử thời lượng của booking này vẫn giữ nguyên
                    double subsequentDuration = subsequent.AppointmentDetail.ServiceHistory.Service.EstimatedHours;
                    subsequent.EstimatedEndTime = newStart.AddHours(subsequentDuration);
                }

                // Cập nhật lại từng booking
                _repoManager.EmployeeSchedule.Update(subsequent);
            }

            if (schedule.AppointmentDetail.PackageHistoryId != null)
            {
                var appointmentDetailPackage = schedule.AppointmentDetail.Appointment.AppointmentDetailPackages.Where(adp => adp.PackageHistoryId.Equals(schedule.AppointmentDetail.PackageHistoryId)).FirstOrDefault();
                if (appointmentDetailPackage.Status != AppointmentDetailPackageStatus.InProgress)
                {
                    appointmentDetailPackage.Status = AppointmentDetailPackageStatus.InProgress;
                    _repoManager.AppointmentDetailPackage.Update(appointmentDetailPackage);
                }
            }

            _repoManager.EmployeeSchedule.Update(schedule);
            await _repoManager.SaveAsync();

            return Result.Ok();
        }

    }
}
