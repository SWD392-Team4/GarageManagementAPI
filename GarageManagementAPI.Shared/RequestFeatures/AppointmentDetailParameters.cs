using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class AppointmentDetailParameters : RequestParameters
    {
        public Guid? AppointmentId { get; set; }

        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus? AppointmentDetailStatus { get; set; }
    }
}
