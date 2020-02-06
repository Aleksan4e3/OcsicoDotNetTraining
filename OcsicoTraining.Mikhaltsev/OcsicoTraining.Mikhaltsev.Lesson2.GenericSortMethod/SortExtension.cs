using System;
using System.Collections.Generic;
using System.Linq;

namespace OcsicoTraining.Mikhaltsev.Lesson2.GenericSortMethod
{
    public static class SortExtension
    {
        public static IEnumerable<T> SortCollection<T>(this IEnumerable<T> collection, SortDirection direction = SortDirection.Ascending)
            where T : IComparable<T> => direction == SortDirection.Ascending ? collection.OrderBy(c => c) : collection.OrderByDescending(c => c);
    }
}
