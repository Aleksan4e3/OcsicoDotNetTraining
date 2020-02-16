using System;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciGenerator.FibonacciGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            TaskFibonacciRun();
            Console.ReadKey();
        }

        private static void TaskFibonacciRun()
        {
            var numbersFibonacci = Generate(15);

            foreach (var number in numbersFibonacci)
            {
                Console.WriteLine(number);
            }
        }
    }
}
