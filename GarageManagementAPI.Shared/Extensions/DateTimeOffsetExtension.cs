namespace GarageManagementAPI.Shared.Extension
{
    public static class DateTimeOffsetExtension
    {
        public static DateTimeOffset GetCurrentTimeInTimeZone(this DateTimeOffset dateTimeOffset, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTime(dateTimeOffset, timeZone);
        }

        public static DateTimeOffset SEAsiaStandardTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.GetCurrentTimeInTimeZone("SE Asia Standard Time");
        }

        public static bool IsWithinBusinessHours(this DateTimeOffset dateTime, TimeSpan businessStart, TimeSpan businessEnd)
        {
            TimeSpan timeOfDay = dateTime.TimeOfDay;
            return timeOfDay >= businessStart && timeOfDay < businessEnd;
        }
    }
}
