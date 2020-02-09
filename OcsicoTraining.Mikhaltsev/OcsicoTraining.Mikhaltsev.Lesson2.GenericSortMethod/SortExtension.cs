using System;
using System.Collections.Generic;
using System.Linq;

namespace OcsicoTraining.Mikhaltsev.Lesson2.GenericSortMethod
{
    public static class SortExtension
    {
        public static IEnumerable<T> SortAsc<T>(this IEnumerable<T> collection) where T : IComparable<T> => collection.Sort((a, b) => a != null && a.CompareTo(b) > 0);

        public static IEnumerable<T> SortDesc<T>(this IEnumerable<T> collection) where T : IComparable<T> => collection.Sort((a, b) => a == null || a.CompareTo(b) < 0);

        private static IEnumerable<T> Sort<T>(this IEnumerable<T> collection, Func<T, T, bool> condition) where T : IComparable<T>
        {
            var list = collection.ToList();

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (condition(list[i], list[j]))
                    {
                        (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }

            return list;
        }
    }
}
