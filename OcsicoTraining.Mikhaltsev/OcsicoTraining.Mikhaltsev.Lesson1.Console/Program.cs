using System;
using OcsicoTraining.Mikhaltsev.Lesson1.NOD;
using static System.Console;

namespace OcsicoTraining.Mikhaltsev.Lesson1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunFindGdcTask();
        }

        private static void RunFindGdcTask()
        {
            var firstValue = ReadValue();
            var secondValue = ReadValue();

            var resultParseFirstValue = ParseValue(firstValue, out int firstNumber);
            var resultParseSecondValue = ParseValue(secondValue, out int secondNumber);

            if (resultParseFirstValue && resultParseSecondValue)
            {
                var nod = Nod.FindNOD(firstNumber, secondNumber);
                WriteLine($"For numbers {firstNumber} and {secondNumber} NOD = {nod}");
            }
            else
            {
                WriteLine("Invalid values entered!!!");
            }
        }

        static string ReadValue()
        {
            WriteLine("Enter number:");
            return ReadLine();
        }

        static bool ParseValue(string value, out int number)
        {
            var parseResult = int.TryParse(value, out int a);
            number = a;
            return parseResult;
        }
    }
}
