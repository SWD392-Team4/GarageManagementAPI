namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory
{
    public record class ServiceHistoryDtoForCreation : ServiceHistoryDtoForManipulation
    {
        public required Guid ServiceId { get; set; }
    }
}
