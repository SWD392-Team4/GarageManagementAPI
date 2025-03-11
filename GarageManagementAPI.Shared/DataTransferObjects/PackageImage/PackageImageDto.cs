namespace GarageManagementAPI.Shared.DataTransferObjects.PackageImage
{
    public record PackageImageDto : BaseDto<PackageImageDto>
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public string? ImageLink { get; set; }
        public string? ImageId { get; set; }
    }
}
