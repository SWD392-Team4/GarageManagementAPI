﻿namespace GarageManagementAPI.Shared.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        public int Order { get; }
        public PropertyOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
