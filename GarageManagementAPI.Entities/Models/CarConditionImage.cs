namespace GarageManagementAPI.Entities.Models
{
    public class CarConditionImage : BaseEntity<CarConditionImage>
    {
        public required Guid AppointmentDetailId { get; set; }

        public required string Link { get; set; }

        public required string CarConditionType { get; set; } //Before or After

        public AppointmentDetail? AppointmentDetail { get; set; }
    }
}