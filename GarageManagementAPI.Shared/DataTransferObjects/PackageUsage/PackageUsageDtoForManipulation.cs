namespace GarageManagementAPI.Shared.DataTransferObjects.PackageUsage
{
    public record PackageUsageDtoForManipulation
    {
        public Guid InvoiceAppointmentId { get; set; }

        public Guid PackageHistoryId { get; set; }

        public Guid CustomerCarId { get; set; }

        public int UsagedCount { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}
