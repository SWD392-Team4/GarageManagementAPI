using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record ReplacementPartDto
    {
        public Guid AppointmentDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public Guid? ProductAtGarageId { get; set; }

        public int Quantity { get; set; }

        [EnumDataType(typeof(AppointmentReplacementPartStatus))]
        public AppointmentReplacementPartStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
