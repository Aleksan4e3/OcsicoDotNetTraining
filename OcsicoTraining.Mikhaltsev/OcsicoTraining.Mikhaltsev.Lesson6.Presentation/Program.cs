using System;
using OcsicoTraining.Mikhaltsev.Lesson6.GenericList;
using OcsicoTraining.Mikhaltsev.Lesson6.Set;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.FibonacciNumbersGenerator;
using static OcsicoTraining.Mikhaltsev.Lesson6.Factorial.FactorialNumber;

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

        private static void TaskGenericListRun()
        {
            var genericList = new List<int>();

            genericList.AddRange(new[] { 1, 2, 3, 4, 5, 6 });
            genericList.Add(7);
            genericList.Add(8);
            genericList.Remove(7);
            genericList.RemoveRange(2, 3);

            foreach (var element in genericList)
            {
                Console.WriteLine(element);
            }
        }

        private static void TaskComputeFactorialRun() => Console.WriteLine(ComputeFactorial(7));
    }
}
