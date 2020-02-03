using System;
using OcsicoTraining.Mikhaltsev.Lesson1.NOD;
using static System.Console;

namespace OcsicoTraining.Mikhaltsev.Lesson1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var value1 = ReadValue();
            var value2 = ReadValue();

            var resultParseValue1 = ParseValue(value1, out int number1);
            var resultParseValue2 = ParseValue(value2, out int number2);

            if (resultParseValue1 && resultParseValue2)
            {
                int nod = Nod.FindNOD(number1, number2);
                WriteLine($"For numbers {number1} and {number2} NOD = {nod}");
            }
            else
            {
                WriteLine("Invalid values entered!!!");
            }
        }

        static string ReadValue()
        {
            WriteLine("Enter number:");
            var value = ReadLine();
            return value;
        }

        static bool ParseValue(string value, out int number)
        {
            var parseResult = int.TryParse(value, out int a);
            number = a;
            return parseResult;
        }
    }
}
