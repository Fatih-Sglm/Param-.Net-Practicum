using Param_.Net_Practicum.Core.Applicaiton.Models;
using System.Linq.Dynamic.Core;
namespace Param_.Net_Practicum.Core.Applicaiton.Extensions
{
    /// <summary>
    /// Adding dynamically incoming property order by to the incoming IQueryable object
    /// </summary>
    public static class DynamicFilterExtenions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Dynamic dynamic)
        {

            if (dynamic.Sort != null)
            {
                if (CheckHasProperty<T>(dynamic.Sort.FieldName))
                {
                    query = query.OrderBy($"{dynamic.Sort.FieldName} {dynamic.Sort.SortingType}");
                }
                else
                {
                    throw new Exception("no such field found");
                }
            }

            return query;
        }
        private static bool CheckHasProperty<T>(string propertyName)
        {
            var properties = typeof(T).GetProperties().Select(x => x.Name.ToLower());
            return properties.Contains(propertyName.ToLower());
        }
    }
}
