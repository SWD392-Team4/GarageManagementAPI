namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback
{
    public record class ServiceFeedbackDtoForCreation : ServiceFeedBackDtoForManipulation
    {
        public required Guid ServiceId { get; set; }
    }
}
