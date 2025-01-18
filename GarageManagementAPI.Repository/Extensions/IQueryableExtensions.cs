using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.CustomAttribute;
using System.Linq.Expressions;
using System.Reflection;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class IQueryableExtensions
    {
        private static Expression CreateProjectionExpression(ParameterExpression parameter, Type type)
        {
            // Lấy danh sách PropertyInfos từ BaseEntity
            var propertyInfos = GetPropertyInfos(type);
            var bindings = new List<MemberBinding>();

            foreach (var property in propertyInfos)
            {
                // Bỏ qua property nếu có [ExcludeFromProjection]

                Expression propertyAccess = Expression.Property(parameter, property);

                if (property.GetCustomAttribute<ChildObjectAttribute>() != null &&
                    property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var childType = property.PropertyType.GetGenericArguments()[0];

                    // Tạo parameter cho từng item trong collection
                    var childParameter = Expression.Parameter(childType, "child");

                    // Gọi đệ quy để tạo projection cho từng item trong collection
                    var childProjection = CreateProjectionExpression(childParameter, childType);

                    var childLambda = Expression.Lambda(childProjection, childParameter);

                    var selectMethod = typeof(Enumerable).GetMethods()
                        .First(m => m.Name == "Select" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(childType, childLambda.ReturnType);

                    propertyAccess = Expression.Call(selectMethod, propertyAccess, childLambda);
                }
                else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Nếu là một object con (không phải collection), tạo projection đệ quy
                    var childParameter = Expression.Parameter(property.PropertyType, "childObject");
                    var childProjection = CreateProjectionExpression(childParameter, property.PropertyType);

                    propertyAccess = childProjection;
                }

                bindings.Add(Expression.Bind(property, propertyAccess));
            }

            return Expression.MemberInit(Expression.New(type), bindings);
        }

        private static PropertyInfo[] GetPropertyInfos(Type type)
        {
            // Kiểm tra xem type có kế thừa BaseEntity hay không
            var baseEntityType = typeof(BaseEntity<>).MakeGenericType(type);
            if (baseEntityType.IsAssignableFrom(type))
            {
                var propertyInfosField = baseEntityType.GetField("PropertyInfos", BindingFlags.Static | BindingFlags.Public);
                if (propertyInfosField != null)
                {
                    return (PropertyInfo[])propertyInfosField.GetValue(null);
                }
            }

            // Nếu không kế thừa BaseEntity, gọi GetProperties thông thường
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
