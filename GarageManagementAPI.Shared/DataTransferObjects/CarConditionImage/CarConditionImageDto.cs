using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage
{
    public class CarConditionImageDto
    {
        public Guid Id { get; set; }

        public Guid AppointmentDetailId { get; set; }

        public string? ImageLink { get; set; }

        public string? ImageId { get; set; }

        [EnumDataType(typeof(ConditionStage))]
        public ConditionStage ConditionStage { get; set; }
    }
}
