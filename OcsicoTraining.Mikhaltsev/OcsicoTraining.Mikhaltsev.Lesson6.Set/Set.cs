using System;
using System.Collections;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Set
{
    public class Set<T> : IEnumerable where T : IComparable<T>
    {
        private readonly List<T> items = new List<T>();

        public Set() { }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public int Count => items.Count;

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("This item already exist");
            }

            items.Add(item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null");
            }

            items.Remove(item);
        }

        public bool Contains(T item) => items.Contains(item);

        public void Clear() => items.Clear();

        public Set<T> UnionWith(Set<T> other)
        {
            var result = new Set<T>(items);

            foreach (var item in other.items)
            {
                if (!Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Set<T> ExceptWith(Set<T> other)
        {
            var result = new Set<T>(items);

            foreach (var item in other.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public Set<T> Intersect(Set<T> other)
        {
            var result = new Set<T>();

            foreach (var item in items)
            {
                if (other.items.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Set<T> SymmetricExcept(Set<T> other)
        {
            var union = UnionWith(other);
            var intersection = Intersect(other);

            return union.ExceptWith(intersection);
        }

        public bool IsSubsetOf(Set<T> other)
        {
            var result = new Set<T>(items);

            foreach (var item in other.items)
            {
                result.Remove(item);
            }

            return result.Count == 0;
        }

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
