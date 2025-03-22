namespace GarageManagementAPI.Shared.Extension
{
    public static class DateTimeExtension
    {
        public static DateTime GetCurrentTimeInTimeZone(this DateTime datetime, string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(datetime, timeZone);
        }

        public static DateTime SEAsiaStandardTime(this DateTime datetime)
        {
            return datetime.GetCurrentTimeInTimeZone("SE Asia Standard Time");
        }

        public static bool IsWithinBusinessHours(this DateTime dateTime, TimeSpan businessStart, TimeSpan businessEnd)
        {
            TimeSpan timeOfDay = dateTime.TimeOfDay;
            return timeOfDay >= businessStart && timeOfDay < businessEnd;
        }
    }
}
