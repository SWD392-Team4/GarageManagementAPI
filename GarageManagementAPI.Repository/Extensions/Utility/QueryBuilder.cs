using System.Reflection;
using System.Text;

namespace GarageManagementAPI.Repository.Extensions.Utility
{
    public static class QueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString, PropertyInfo[] propertyInfos)
        {
            var orderParams = orderByQueryString.Trim().Split(',');
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.CurrentCultureIgnoreCase));

                if (objectProperty is null) continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
