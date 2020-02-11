using System;

namespace OcsicoTraining.Mikhaltsev.Lesson2.GenericQueue
{
    public class Queue<T>
    {
        private readonly int size;
        private int head = -1;
        private int tail = -1;
        private T[] array;

        public Queue(int size)
        {
            this.size = size;
            array = new T[size];
        }

        public int Count { get; set; } = 0;

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                TrimToSize();
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
            array = new T[size];
            head = -1;
            tail = -1;
        }

        private bool IsFull() => tail == size - 1;

        private bool IsEmpty() => Count == 0;

        private void TrimToSize()
        {
            var newArray = new T[size * 2];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }
    }
}
