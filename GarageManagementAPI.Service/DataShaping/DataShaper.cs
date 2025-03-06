using System.Dynamic;
using System.Reflection;
using AutoMapper.Internal;
using GarageManagementAPI.Service.Contracts;

namespace GarageManagementAPI.Service.DataShaping
{
    //where T : class chỉ định rằng tham số kiểu T phải là một kiểu tham chiếu (reference type), tức là T phải là một lớp (class), không phải kiểu giá trị (struct, int, double, v.v...).
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Properties { get; set; }

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

        private Dictionary<string, List<string>> GetRequiredProperties(string? fieldsString)
        {
            var propertyMapping = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

            if (string.IsNullOrWhiteSpace(fieldsString))
            {
                // If no fields specified, include all root properties without nesting
                foreach (var property in Properties)
                {
                    propertyMapping.Add(property.Name, new List<string>());
                }
                return propertyMapping;
            }

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var trimmedField = field.Trim();
                var segments = trimmedField.Split('.');

                if (segments.Length == 0)
                    continue;

                var rootProperty = segments[0];
                var propertyInfo = Properties.FirstOrDefault(pi =>
                    pi.Name.Equals(rootProperty, StringComparison.InvariantCultureIgnoreCase));

                if (propertyInfo == null)
                    continue;

                if (!propertyMapping.ContainsKey(rootProperty))
                {
                    propertyMapping.Add(rootProperty, new List<string>());
                }

                if (segments.Length > 1)
                {
                    var nestedFields = string.Join('.', segments.Skip(1));
                    // Add the nested property path (everything after the first segment)
                    propertyMapping[rootProperty].Add(nestedFields);
                }
            }

            return propertyMapping;
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, Dictionary<string, List<string>> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();

            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        private ExpandoObject FetchDataForEntity(T entity, Dictionary<string, List<string>> requiredProperties)
        {
            var shapedObject = new ExpandoObject();
            var expandoDict = shapedObject as IDictionary<string, object>;

            foreach (var property in requiredProperties)
            {
                var propertyInfo = Properties.FirstOrDefault(pi =>
                    pi.Name.Equals(property.Key, StringComparison.InvariantCultureIgnoreCase));

                if (propertyInfo == null)
                    continue;

                var propertyValue = propertyInfo.GetValue(entity);
                //if (propertyValue == null)
                //    continue;

                var propertyName = char.ToLower(property.Key[0]) + property.Key.Substring(1);

                // Handle nested properties
                if (property.Value.Any())
                {
                    if (propertyValue is IEnumerable<object> collection && !(propertyValue is string))
                    {
                        // Handle collection properties (like Images in the example)
                        var shapedCollection = new List<ExpandoObject>();

                        foreach (var item in collection)
                        {
                            var shapedItem = new ExpandoObject();
                            var itemDict = shapedItem as IDictionary<string, object>;

                            foreach (var nestedPath in property.Value)
                            {
                                // Process each nested property (like Url in Images.Url)
                                ProcessNestedProperty(item, nestedPath, itemDict);
                            }

                            if (itemDict.Count > 0)
                            {
                                shapedCollection.Add(shapedItem);
                            }
                        }

                        if (shapedCollection.Any())
                        {
                            expandoDict[propertyName] = shapedCollection;
                        }
                    }
                    else
                    {
                        // Handle single nested objects
                        var nestedObject = new ExpandoObject();
                        var nestedDict = nestedObject as IDictionary<string, object>;

                        foreach (var nestedPath in property.Value)
                        {
                            ProcessNestedProperty(propertyValue, nestedPath, nestedDict);
                        }

                        if (nestedDict.Count > 0)
                        {
                            expandoDict[propertyName] = nestedObject;
                        }
                    }
                }
                else
                {
                    // Simple property (no nesting)
                    expandoDict[propertyName] = propertyValue;
                }
            }

            return shapedObject;
        }

        private void ProcessNestedProperty(object entity, string propertyPath, IDictionary<string, object> result)
        {
            var segments = propertyPath.Split('.');
            var currentProperty = segments[0];

            // Find property on the current entity
            var propertyInfo = entity.GetType().GetProperty(currentProperty,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (propertyInfo == null)
                return;

            var propertyValue = propertyInfo.GetValue(entity);
            //if (propertyValue == null)
            //    return;

            var propertyName = char.ToLower(currentProperty[0]) + currentProperty.Substring(1);

            if (segments.Length > 1)
            {
                // There are more segments to process (deeper nesting)
                var remainingPath = string.Join('.', segments.Skip(1));

                if (propertyValue is IEnumerable<object> collection && !(propertyValue is string))
                {
                    // Handle nested collection
                    var nestedCollection = new List<ExpandoObject>();

                    foreach (var item in collection)
                    {
                        var nestedObject = new ExpandoObject();
                        var nestedDict = nestedObject as IDictionary<string, object>;

                        ProcessNestedProperty(item, remainingPath, nestedDict);

                        if (nestedDict.Count > 0)
                        {
                            nestedCollection.Add(nestedObject);
                        }
                    }

                    if (nestedCollection.Any())
                    {
                        result[propertyName] = nestedCollection;
                    }
                }
                else
                {
                    // Handle nested object
                    var nestedObject = new ExpandoObject();
                    var nestedDict = nestedObject as IDictionary<string, object>;

                    ProcessNestedProperty(propertyValue, remainingPath, nestedDict);

                    if (nestedDict.Count > 0)
                    {
                        result[propertyName] = nestedObject;
                    }
                }
            }
            else
            {
                // This is the final property in the path
                result[propertyName] = propertyValue;
            }
        }
    }
}

