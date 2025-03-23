namespace GarageManagementAPI.Entities.Models
{
    public class ReplacementPart_ProductAtGarage : BaseEntity<ReplacementPart_ProductAtGarage>
    {
        public Guid ProductAtGarageId { get; set; }
        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;

        public Guid ReplacementPartId { get; set; }
        public virtual ReplacementPart ReplacementPart { get; set; } = null!;

        public int QuantityUsed { get; set; }
    }

}

