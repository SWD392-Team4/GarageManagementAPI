namespace GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule
{
    public record EmployeeScheduleDtoForUnassign
    {
        public Guid EmployeeId { get; set; }

        public bool IsCancel { get; set; }

        public bool IsDecline { get; set; }
    }

}
