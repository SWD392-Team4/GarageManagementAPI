namespace GarageManagementAPI.Shared.Enums.SystemStatuss
{
    public enum EmployeeScheduleStatus
    {
        Assigned = 1,
        Declined = 2, //mechanic declined the schedule
        Cancelled = 3, //customer cancelled the schedule
        InProgress = 4,
        Completed = 5,
    }
}
