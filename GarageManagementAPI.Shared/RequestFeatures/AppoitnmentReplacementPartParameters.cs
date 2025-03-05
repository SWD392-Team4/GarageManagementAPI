using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class AppoitnmentReplacementPartParameters : RequestParameters
    {
        public Guid? AppointmentId { get; set; }

        public Guid? AppointmentDetailId { get; set; }

        [EnumDataType(typeof(AppointmentReplacementPartStatus))]
        public AppointmentReplacementPartStatus? AppointmentReplacementPartStatus { get; set; }
    }
}
