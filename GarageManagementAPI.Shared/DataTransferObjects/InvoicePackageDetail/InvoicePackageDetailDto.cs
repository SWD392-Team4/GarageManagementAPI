using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;

namespace GarageManagementAPI.Shared.DataTransferObjects.InvoicePackageDetail
{
    public class InvoicePackageDetailDto
    {
        public Guid InvoiceId { get; set; }

        public Guid PackageHistoryId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual PackageHistoryDto PackageHistory { get; set; } = null!;
    }
}
