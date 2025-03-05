namespace GarageManagementAPI.Shared.DataTransferObjects.PackageFeedBack
{
    public record PackageFeedBackDtoForManipulation
    {
        public Guid CustomerId { get; set; }

        public Guid PackageId { get; set; }

        public string? FeedBack { get; set; }

        public string? Emoji { get; set; }
    }
}
