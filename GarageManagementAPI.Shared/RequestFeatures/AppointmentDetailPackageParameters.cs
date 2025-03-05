using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class AppointmentDetailPackageParameters : RequestParameters
    {
        public Guid? AppointmentId { get; set; }

        [EnumDataType(typeof(AppointmentDetailPackageStatus))]
        public AppointmentDetailPackageStatus? AppointmentDetailPackageStatus { get; set; }
    }
}
