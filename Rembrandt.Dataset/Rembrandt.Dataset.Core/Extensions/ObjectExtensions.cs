using System;

namespace Rembrandt.Dataset.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static T CheckForNullable<T>(this object obj, T objClass)
            => objClass == null ? throw new ArgumentNullException($"Property '{typeof(T).Name}' can not be null!") : objClass;
    }
}