namespace GarageManagementAPI.Shared.DataTransferObjects.PackageDetail
{
    public record PackageDetailDtoForManipulation
    {
        public IEnumerable<Guid>? ServiceList { get; set; }
    }
}
