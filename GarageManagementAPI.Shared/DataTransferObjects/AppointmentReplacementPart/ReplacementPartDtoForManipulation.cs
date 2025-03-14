namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record ReplacementPartDtoForManipulation
    {
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
