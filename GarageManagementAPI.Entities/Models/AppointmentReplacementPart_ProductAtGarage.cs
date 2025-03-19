namespace GarageManagementAPI.Entities.Models
{
    public class AppointmentReplacementPart_ProductAtGarage : BaseEntity<AppointmentReplacementPart_ProductAtGarage>
    {
        public Guid ProductAtGarageId { get; set; }
        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;
        public Guid AppointmentReplacementPartId { get; set; }
        public virtual AppointmentReplacementPart AppointmentReplacementPart { get; set; } = null!;
        public int QuantityUsed { get; set; }
    }
}
