using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class AppointmentParameters : RequestParameters
    {
        public Guid? Employee { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CarLicensePlateNumber { get; set; }

        [EnumDataType(typeof(AppointmentType))]
        public AppointmentType? AppointmentType { get; set; }

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus? AppointmentStatus { get; set; }
    }
}
