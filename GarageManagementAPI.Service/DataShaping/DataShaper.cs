﻿using AutoMapper.Internal;
using GarageManagementAPI.Service.Contracts;
using System.Dynamic;
using System.Reflection;

namespace GarageManagementAPI.Service.DataShaping
{
    //where T : class chỉ định rằng tham số kiểu T phải là một kiểu tham chiếu (reference type), tức là T phải là một lớp (class), không phải kiểu giá trị (struct, int, double, v.v...).
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Properties { get; set; }
        //PropertyInfo: System.Reflection
        public DataShaper(PropertyInfo[] propertyInfo)
        {
            Properties = propertyInfo;
        }

        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string? fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);
            return FetchData(entities, requiredProperties);
        }

        public ExpandoObject ShapeData(T entity, string? fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);
            return FetchDataForEntity(entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return Properties.ToList();

            var requiredProperties = new List<PropertyInfo>();

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var property = Properties.FirstOrDefault(pi =>
                pi.Name
                .Equals(
                    field.Trim(),
                    StringComparison.InvariantCultureIgnoreCase));

                // Nếu không tìm thấy thuộc tính, tiếp tục với thuộc tính tiếp theo
                if (property == null)
                    continue;

                requiredProperties.Add(property);
            }

            return requiredProperties;
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();

            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredPropertites)
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in requiredPropertites)
            {
                var objectPropertyValue = property.GetValue(entity);
                if (objectPropertyValue != null)
                    shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }
    }
}

