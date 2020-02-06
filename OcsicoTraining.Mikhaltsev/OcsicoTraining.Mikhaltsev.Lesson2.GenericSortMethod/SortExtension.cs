using System;
using System.Collections.Generic;
using System.Linq;

namespace OcsicoTraining.Mikhaltsev.Lesson2.GenericSortMethod
{
    public static class SortExtension
    {
        public static IEnumerable<T> SortAsc<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            var list = collection.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (list[i].CompareTo(list[j]) > 0)
                    {
                        (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }

            return list;
        }

        public static IEnumerable<T> SortDesc<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            var list = collection.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (list[i].CompareTo(list[j]) < 0)
                    {
                        (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }

            return list;
        }
    }
}
