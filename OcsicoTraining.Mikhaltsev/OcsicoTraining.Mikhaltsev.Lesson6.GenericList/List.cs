using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.GenericList
{
    public class List<T>
    {
        private T[] array;
        private int size;

        public List() : this(10) { }

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
                throw new ArgumentOutOfRangeException("List is full");
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
            Array.Copy(array, index + count, array, index, size - index - count);
            Array.Clear(array, size - count, count);
            size -= count;
        }

        private int IndexOf(T item) => Array.IndexOf(array, item);

        private void RemoveAt(int index)
        {
            Array.Copy(array, index + 1, array, index, size - index - 1);
            size--;
        }

        private bool IsFull() => size == array.Length;
    }
}
