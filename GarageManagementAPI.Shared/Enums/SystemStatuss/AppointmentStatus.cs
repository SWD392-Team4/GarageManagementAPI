namespace GarageManagementAPI.Shared.Enums.SystemStatuss
{
    public enum AppointmentStatus
    {
        Pending = 1,
        Approved = 2, // Approved by employee
        Rejected = 3, // Rejected by employee
        Cancelled = 4, // Canceled by customer
        Arrival = 5, // Customer arrived at the garage
        InProgress = 6,
        Completed = 7
    }
}
