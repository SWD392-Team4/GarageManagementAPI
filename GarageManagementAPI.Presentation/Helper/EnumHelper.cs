namespace GarageManagementAPI.Presentation.Helper
{
    public class EnumHelper
    {
        public static bool TryParseEnum<TEnum>(object value, out TEnum result) where TEnum : struct, Enum
        {
            result = default;

            if (value is int intValue)
            {
                if (Enum.IsDefined(typeof(TEnum), intValue))
                {
                    result = (TEnum)Enum.ToObject(typeof(TEnum), intValue);
                    return true;
                }
            }

            if (value is string stringValue)
            {
                return Enum.TryParse(stringValue, ignoreCase: true, out result) && Enum.IsDefined(typeof(TEnum), result);
            }

            return false;
        }
    }
}