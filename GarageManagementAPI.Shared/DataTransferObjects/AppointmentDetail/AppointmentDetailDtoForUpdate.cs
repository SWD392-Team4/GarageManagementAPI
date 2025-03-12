using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail
{
    public class AppointmentDetailDtoForUpdate : AppointmentDetailDtoForManipulation
    {
        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus Status { get; set; }

        public string? ServiceNote { get; set; }
    }

}
