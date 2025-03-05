namespace GarageManagementAPI.Shared.DataTransferObjects.PackageUsageDetail
{
    public record PackageUsageDetailDtoForManipulation
    {
        public Guid PackageUsageId { get; set; }

        public Guid AppointmentId { get; set; }
    }
}
