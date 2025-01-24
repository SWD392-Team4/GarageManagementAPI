namespace GarageManagementAPI.Entities.Models
{
    public class AppointmentReplacementParts : BaseEntity<AppointmentReplacementParts>
    {
        public Guid AppointmentDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public int Quantity { get; set; }

        public AppointmentDetail? AppointmentDetail { get; set; }

        public ProductHistory? ProductHistory { get; set; }
    }
}