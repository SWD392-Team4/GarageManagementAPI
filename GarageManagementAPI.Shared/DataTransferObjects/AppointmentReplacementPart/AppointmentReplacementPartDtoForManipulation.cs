namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart
{
    public record AppointmentReplacementPartDtoForManipulation
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
