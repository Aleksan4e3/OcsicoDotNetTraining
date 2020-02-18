using System;
using OcsicoTraining.Mikhaltsev.Lesson6.Set;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.FibonacciNumbersGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            TaskOperationWithSetRun();
            Console.ReadKey();
        }

        private static void TaskFibonacciNumbersRun()
        {
            var fibonacciNumbers = Generate(15);

            foreach (var number in fibonacciNumbers)
            {
                Console.WriteLine(number);
            }
        }

        private static void TaskOperationWithSetRun()
        {
            var firstSet = new Set<int>(new[] { 1, 3, 5, 2, 4 });
            var secondSet = new Set<int>(new[] { 3, 4, 7, 6, 5 });

            firstSet.Intersect(secondSet);

            foreach (var item in firstSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(firstSet.IsSubsetOf(secondSet));
        }
    }
}
