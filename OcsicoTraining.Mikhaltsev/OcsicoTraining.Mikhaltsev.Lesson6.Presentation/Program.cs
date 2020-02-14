using System;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciGenerator.FibonacciGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            var fibonacci = Generate(-1);
            foreach (var i in fibonacci)
            {
                Console.WriteLine(i);
            }
        }
    }
}
