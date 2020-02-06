using System;
using System.Diagnostics.CodeAnalysis;

namespace OcsicoTraining.Mikhaltsev.Lesson2.Presentation
{
    public class User : IComparable<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] User other) => other == null ? 1 : Age.CompareTo(other.Age);
    }
}
