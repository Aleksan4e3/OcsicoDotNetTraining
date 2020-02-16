using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Set
{
    public class SetEnumerator<T> where T : IComparable<T>
    {
        private readonly Set<T> set;

        public SetEnumerator(Set<T> set)
        {
            this.set = set;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < set.Count; i++)
            {
                yield return set[i];
            }
        }
    }
}
