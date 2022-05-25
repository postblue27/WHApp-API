using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WHApp_API.Data
{
    public static class Extensions
    {
        public static void MapProperties<TSource, TDestination>(this TSource source, TDestination destination)
                where TSource : class, new()
                where TDestination : class, new()
        {
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name.ToLower() == sourceProperty.Name.ToLower());

                    if (destinationProperty != null)
                    {
                        try
                        {
                            destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
            }
        }
        public static Type GetTypeFullName(string namespaceName, string typeName)
        {
            return Assembly.GetExecutingAssembly().GetType($"{namespaceName}.{typeName}", true);
        }
        public static object GetTypedUserInstance(object userDataToMap, Type userType)
        {
            object typedUser = Activator.CreateInstance(userType);
            Extensions.MapProperties(userDataToMap, typedUser);
            return typedUser;
        }
    }
}