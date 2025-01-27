namespace GarageManagementAPI.Entities.Models
{
    public partial class InvoiceServiceDetail : BaseEntity<InvoiceServiceDetail>
    {
        public Guid ServiceHistoryId { get; set; }

        public Guid InvoiceId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;

        public virtual ICollection<ReplacementPart> ReplacementParts { get; set; } = new List<ReplacementPart>();

        public virtual ServiceHistory ServiceHistory { get; set; } = null!;
    }

}

