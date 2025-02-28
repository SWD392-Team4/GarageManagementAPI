namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback
{
    public record class ServiceFeedBackDtoForManipulation
    {
        public string FeedBack { get; set; } = null!;
        public string Emoji { get; set; } = null!;
    }
}
