namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record ReplacementPartDtoForManipulation
    {
        public Guid ProductHistoryId { get; set; }
        public int Quantity { get; set; }
    }
}
