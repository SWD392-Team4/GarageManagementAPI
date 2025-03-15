namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail
{
    public record AppointmentDetailDtoForCancellation
    {
        public Guid[]? AppointmentDetailId { get; init; }

        public string? CancelReason { get; init; }
    }
}
