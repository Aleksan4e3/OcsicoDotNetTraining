using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Set
{
    public class SetEnumerator<T> where T : IComparable<T>
    {
        private readonly List<T> items;

        public SetEnumerator(List<T> items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
