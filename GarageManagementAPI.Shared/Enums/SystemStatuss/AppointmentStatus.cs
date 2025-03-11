namespace GarageManagementAPI.Shared.Enums.SystemStatuss
{
    public enum AppointmentStatus
    {
        Pending = 1,
        Approved = 2, // Approved by employee
        Declined = 3, // Declined by employee
        Canceled = 4, // Canceled by customer
        InProgress = 6,
        Completed = 7
    }
}
