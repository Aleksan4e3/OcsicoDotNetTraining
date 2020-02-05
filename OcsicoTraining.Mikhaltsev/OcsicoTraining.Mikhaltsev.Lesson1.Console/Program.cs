using static OcsicoTraining.Mikhaltsev.Lesson1.NOD.Nod;
using static OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort.BubbleSort;
using static System.Console;
using System;
using System.Linq;

namespace OcsicoTraining.Mikhaltsev.Lesson1.Console
{
    internal class Program
    {
        private static void Main() => RunFindGdcTask();

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

        private static string ReadValue()
        {
            WriteLine("Enter number:");
            return ReadLine();
        }

        private static int[][] CreateRandomJaggedArray()
        {
            var rnd = new Random();
            var randomArray = new int[rnd.Next(3, 6)][];

            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = new int[rnd.Next(2, 5)];
                for (var j = 0; j < randomArray[i].Length; j++)
                {
                    randomArray[i][j] = rnd.Next(-5, 5);
                }
            }

            return randomArray;
        }

        private static void PrintJaggedArray(int[][] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array[i].Length; j++)
                {
                    Write($"{array[i][j]}, ");
                }
                WriteLine();
            }
        }

        private static void RunSortTask()
        {
            var randomArray = CreateRandomJaggedArray();
            WriteLine("Array before sorting:");
            PrintJaggedArray(randomArray);

            WriteLine("Array after sorting:");
            var sortedArray = Sort(randomArray, (a, b) => a.Sum() > b.Sum());
            PrintJaggedArray(sortedArray);
        }
    }
}
