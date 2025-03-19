using GarageManagementAPI.Shared.Enums.SystemStatuss;

using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record AppointmentReplacementPartDtoForUpdate : AppointmentReplacementPartDtoForManipulation
    {

        [EnumDataType(typeof(AppointmentReplacementPartStatus))]
        public AppointmentReplacementPartStatus Status { get; set; }
    }


}
