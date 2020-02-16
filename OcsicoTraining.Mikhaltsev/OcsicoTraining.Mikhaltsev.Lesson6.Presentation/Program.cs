using System;
using OcsicoTraining.Mikhaltsev.Lesson6.GenericList;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.FibonacciNumbersGenerator;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            TaskGenericListRun();
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
    }
}
