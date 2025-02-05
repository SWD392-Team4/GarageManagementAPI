namespace GarageManagementAPI.Service.Extension
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
    }
}
