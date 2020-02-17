using System;
using System.Collections;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.GenericList
{
    public class List<T> : IEnumerable<T>
    {
        private T[] array;
        private int size;

        public List() : this(16) { }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity must not be negative");
            }

            array = new T[capacity];
        }

        public void Add(T item)
        {
            if (IsFull())
            {
                TrimToSize();
            }

            array[size++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Remove(T item)
        {
            var index = IndexOf(item);
            RemoveAt(index);
        }

        public void RemoveRange(int index, int count)
        {
            var length = size - index - count;

            if (index < 0 || index >= size || length < 0)
            {
                throw new IndexOutOfRangeException("The index was out of range");
            }

            Array.Copy(array, index + count, array, index, length);
            Array.Clear(array, size - count, count);
            size -= count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < size; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int IndexOf(T item) => Array.IndexOf(array, item);

        private void RemoveAt(int index)
        {
            Array.Copy(array, index + 1, array, index, size - index - 1);
            size--;
        }

        private bool IsFull() => size == array.Length;

        private void TrimToSize()
        {
            var newArray = new T[size * 2];
            Array.Copy(array, newArray, size);
            array = newArray;
        }
    }
}
