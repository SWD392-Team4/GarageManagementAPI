using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service
{
    public class AppointmentDetailPackageService : IAppointmentDetailPackageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public AppointmentDetailPackageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result> UpdateAppointmentDetailPackage(Guid garageId, Guid appointmentId, Guid appointmentDetailPackageId, AppointmentDetailPackageDtoForUpdate appointmentDetailPackageDtoForUpdate)
        {
            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, false);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var appointment = await _repoManager.Appointment.GetAppointmentAsync(garageId, appointmentId, true);
            if (appointment is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetailPackage = appointment.AppointmentDetailPackages.Where(adp => adp.Id.Equals(appointmentDetailPackageId)).FirstOrDefault();
            if (appointmentDetailPackage is null)
                return Result.NotFound(AppointmentErrors.GetAppointmentDetailPackageNotFoundError(appointmentDetailPackageId));

            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            if (appointmentDetailPackageDtoForUpdate.Status == AppointmentDetailPackageStatus.Approved)
            {
                UpdateAppointmentDetailOfPackage(appointment.AppointmentDetails, AppointmentDetailStatus.Approved, now, appointmentDetailPackage.PackageHistoryId);
            }
            else if (appointmentDetailPackageDtoForUpdate.Status == AppointmentDetailPackageStatus.Declined)
            {
                UpdateAppointmentDetailOfPackage(appointment.AppointmentDetails, AppointmentDetailStatus.Declined, now, appointmentDetailPackage.PackageHistoryId);
            }
            else if (appointmentDetailPackageDtoForUpdate.Status == AppointmentDetailPackageStatus.Cancelled)
            {
                UpdateAppointmentDetailOfPackage(appointment.AppointmentDetails, AppointmentDetailStatus.Cancelled, now, appointmentDetailPackage.PackageHistoryId);
            }

            await _repoManager.SaveAsync();

            return Result.Ok();

        }


        private void UpdateAppointmentDetailOfPackage(IEnumerable<AppointmentDetail> appointmentDetails, AppointmentDetailStatus appointmentDetailStatus, DateTimeOffset now, Guid packageHistoryId)
        {
            var appointmentDetailsToUpdate = appointmentDetails.Where(ad => ad.PackageHistoryId.Equals(packageHistoryId));
            foreach (var appointmentDetail in appointmentDetailsToUpdate)
            {
                appointmentDetail.Status = appointmentDetailStatus;
                appointmentDetail.UpdatedAt = now;
            }
        }
    }
}
