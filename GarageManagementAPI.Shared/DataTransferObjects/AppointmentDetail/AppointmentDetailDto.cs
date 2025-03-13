using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail
{
    public class AppointmentDetailDto
    {
        public Guid ServiceHistoryId { get; set; }

        public Guid AppointmentId { get; set; }

        public string ServiceNote { get; set; } = null!;

        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus Status { get; set; }

        public DateTimeOffset CreateAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual IEnumerable<ReplacementPartDto>? ReplacementParts { get; set; }
    }

}
