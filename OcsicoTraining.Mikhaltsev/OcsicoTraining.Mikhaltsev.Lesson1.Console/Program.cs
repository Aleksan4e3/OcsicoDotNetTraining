using static OcsicoTraining.Mikhaltsev.Lesson1.NOD.Nod;
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

            var resultParseFirstValue = int.TryParse(firstValue, out var firstNumber);
            var resultParseSecondValue = int.TryParse(secondValue, out var secondNumber);

            if (resultParseFirstValue && resultParseSecondValue)
            {
                var nod = FindNOD(firstNumber, secondNumber);
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
    }
}
