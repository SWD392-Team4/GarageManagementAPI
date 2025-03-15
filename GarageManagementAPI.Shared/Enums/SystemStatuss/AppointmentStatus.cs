namespace GarageManagementAPI.Shared.Enums.SystemStatuss
{
    public enum AppointmentStatus
    {
        Pending = 1,
        Approved = 2, // Approved by employee
        Rejected = 3, // Rejected by employee
        Cancelled = 4, // Canceled by customer
        InProgress = 6,
        Completed = 7
    }
}
