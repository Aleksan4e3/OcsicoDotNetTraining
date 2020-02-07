using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson2.GenericQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private int head = -1;
        private int tail = -1;
        private readonly int size;
        private T[] array;
        public int Count { get; set; } = 0;

        public Queue(int size)
        {
            this.size = size;
            array = new T[size];
        }

        public bool IsFull() => tail == size - 1;

        public bool IsEmpty() => Count == 0;

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new Exception("Queue is full");
            }

            array[++tail] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var value = array[++head];
            Count--;
            if (head == tail)
            {
                head = -1;
                tail = -1;
            }
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var value = array[head + 1];
            return value;
        }

        public bool Contains(T item) => Array.IndexOf(array, item, head + 1, Count) >= 0;

        public void Clear()
        {
            array = new T[0];
            head = -1;
            tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            for (var i = head + 1; i <= tail; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
