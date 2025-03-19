using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForCheckPriceResponse
    {
        public decimal Price { get; set; }

        public IEnumerable<AppointmentDetailDto>? AppointmentDetails { get; set; }

        public IEnumerable<AppointmentDetailPackageDto>? AppointmentDetailPackages { get; set; }
    }
}
