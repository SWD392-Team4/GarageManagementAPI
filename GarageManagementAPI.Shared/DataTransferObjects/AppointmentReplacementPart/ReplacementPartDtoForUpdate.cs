using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record ReplacementPartDtoForUpdate : ReplacementPartDtoForManipulation
    {
        public Guid? ProductAtGarageId { get; set; }

        [EnumDataType(typeof(AppointmentReplacementPartStatus))]
        public AppointmentReplacementPartStatus Status { get; set; }
    }


}
