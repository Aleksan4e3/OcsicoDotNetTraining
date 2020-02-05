using System;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort;
using static OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort.BubbleSort;

namespace OcsicoTraining.Mikhaltsev.Lesson1.SortPresentation
{
    internal class Program
    {
        private static void Main() => RunSortTask();

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
                    Console.Write($"{array[i][j]}, ");
                }
                Console.WriteLine();
            }
        }

        private static void RunSortTask()
        {
            var randomArray = CreateRandomJaggedArray();
            Console.WriteLine("Array before sorting:");
            PrintJaggedArray(randomArray);

            Console.WriteLine("Array after sorting:");
            var sortedArray = Sort(randomArray, (a, b) => a.Sum() > b.Sum());
            PrintJaggedArray(sortedArray);
        }
    }
}
