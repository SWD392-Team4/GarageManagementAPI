using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForCreation : AppointmentDtoForManipulation
    {
        public IEnumerable<AppointmentDetailDtoForCreation>? Services { get; set; }

        public IEnumerable<AppointmentDetailPackageDtoForCreation>? Packages { get; set; }
    }
}
