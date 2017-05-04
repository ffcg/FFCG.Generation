using System;
using System.Reflection;

namespace FFCG.G5.Storage
{
    public static class ObjectExtensions
    {
        public static object GetId(this object item)
        {
            var idProperty = item.GetIdProperty();
            if (idProperty == null)
                throw new InvalidOperationException("Must have an Id property!");

            var value = idProperty.GetValue(item);
            return value;
        }

        public static PropertyInfo GetIdProperty(this object item)
        {
            Type itemType = item.GetType();
            var idProperty = itemType.GetProperty("Id");
            return idProperty;
        }
    }
}