using System;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciGenerator.FibonacciGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            TaskFibonacciRun();
            _ = Console.ReadKey();
        }

        private static void TaskFibonacciRun()
        {
            var fibonacci = Generate(15);

            foreach (var number in fibonacci)
            {
                Console.WriteLine(number);
            }
        }
    }
}
