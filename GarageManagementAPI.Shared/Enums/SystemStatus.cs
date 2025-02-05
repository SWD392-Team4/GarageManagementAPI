namespace GarageManagementAPI.Shared.Enums
{
    //public class SystemStatus
    //{
    //    public const string Active = "active";
    //    public const string Inactive = "inactive";

    //    private static readonly HashSet<string> ValidStatuss = new()
    //    {
    //        Active,
    //        Inactive
    //    };
    //    public static bool ValidStatus(string? status)
    //    {
    //        return status != null && ValidStatuss.Contains(status);
    //    }
    //}
    public enum SystemStatus
    {
        Inactive = 0,
        Active = 1
    }
}
