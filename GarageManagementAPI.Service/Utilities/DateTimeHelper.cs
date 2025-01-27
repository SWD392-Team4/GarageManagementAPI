namespace GarageManagementAPI.Service.Utilities
{
    public class DateTimeHelper
    {

        public static DateTimeOffset GetCurrentTimeInTimeZone(string timeZoneId)
        {
            var utcNow = DateTimeOffset.UtcNow;
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTime(utcNow, timeZone);
        }

        public static DateTimeOffset SEAsiaStandardTime()
        {
            return GetCurrentTimeInTimeZone("SE Asia Standard Time");
        }
    }
}
