using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentDetailPackageService
    {
        Task<Result> UpdateAppointmentDetailPackage(Guid garageId, Guid appointmentId, Guid appointmentDetailPackageId, AppointmentDetailPackageDtoForUpdate appointmentDetailPackageDtoForUpdate);
    }
}
