using System;
using System.Collections;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Set
{
    public class Set<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> items = new List<T>();

        public Set() { }

        public Set(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public int Count => items.Count;

        public bool Add(T item)
        {
            if (Contains(item))
            {
                return false;
            }

            items.Add(item);

            return true;
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null");
            }

            return items.Remove(item);
        }

        public bool Contains(T item) => items.Contains(item);

        public void Clear() => items.Clear();

        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    items.Add(item);
                }
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                items.Remove(item);
            }
        }

        public void Intersect(IEnumerable<T> other)
        {
            var tempItems = new List<T>();

            foreach (var item in other)
            {
                if (items.Contains(item))
                {
                    tempItems.Add(item);
                }
            }

            items = tempItems;
        }

        public void SymmetricExcept(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            var result = new Set<T>(items);

            foreach (var item in other)
            {
                result.Remove(item);
            }

            return result.Count == 0;
        }

        public IEnumerator<T> GetEnumerator() => new SetEnumerator<T>(items).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
