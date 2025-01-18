using System.Reflection;

namespace GarageManagementAPI.Shared.DataTransferObjects
{
    public abstract record BaseDto<T>
    {
        public static readonly PropertyInfo[] PropertyInfos;

        static BaseDto()
        {
            PropertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
