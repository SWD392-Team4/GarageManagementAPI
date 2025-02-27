namespace GarageManagementAPI.Shared.DataTransferObjects.ProductHistory
{
    public record ProductHistoryDtoForCreation : ProductHistoryDtoForManipulation
    {
        public required Guid ProductId { get; set; }
    }
}
