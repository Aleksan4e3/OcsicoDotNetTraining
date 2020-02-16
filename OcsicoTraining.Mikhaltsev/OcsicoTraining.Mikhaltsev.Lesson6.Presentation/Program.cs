using System;
using static OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator.FibonacciNumbersGenerator;
using static OcsicoTraining.Mikhaltsev.Lesson6.Factorial.FactorialNumber;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            TaskComputeFactorialRun();
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

        private static void TaskComputeFactorialRun() => Console.WriteLine(ComputeFactorial(7));
    }
}
