using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail
{
    public class AppointmentDetailDto
    {
        public Guid Id { get; set; }

        public Guid ServiceHistoryId { get; set; }

        public Guid ServiceId { get; set; }

        public Guid AppointmentId { get; set; }

        public bool IsFromPackage { get; set; }

        public string ServiceNote { get; set; } = null!;

        [EnumDataType(typeof(AppointmentDetailStatus))]
        public AppointmentDetailStatus Status { get; set; }

        public DateTimeOffset CreateAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual IEnumerable<AppointmentReplacementPartDto>? AppointmentReplacementParts { get; set; }

        public IEnumerable<CarConditionImageDto>? CarConditionImages { get; set; }

        public int? EstimatedHours { get; set; }

        public string? ServiceName { get; set; }

        public decimal? Price { get; set; }
    }

}
