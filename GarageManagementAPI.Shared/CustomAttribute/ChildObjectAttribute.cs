using System.Reflection;

namespace GarageManagementAPI.Shared.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ChildObjectAttribute : Attribute
    {

    }
}
