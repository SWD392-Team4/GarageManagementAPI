namespace GarageManagementAPI.Entities.Models
{
    public partial class InvoicePackageDetail : BaseEntity<InvoicePackageDetail>
    {
        public Guid InvoiceId { get; set; }

        public Guid PackageHistoryId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;

        public virtual PackageHistory PackageHistory { get; set; } = null!;
    }

}

