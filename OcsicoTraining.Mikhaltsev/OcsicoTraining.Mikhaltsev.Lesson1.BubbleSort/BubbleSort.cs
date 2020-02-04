using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort
{
    public static class BubbleSort
    {
        static int GetSumElements(int[] array) => array.Sum();

        static int GetMaxElement(int[] array) => array.Max();

        static int GetMinElement(int[] array) => array.Min();

        static void Swap(int[] a, int[] b) => (a, b) = (b, a);

        static int[][] SortAsc(int[][] array, Func<int[], int> sortOption)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sortOption(array[i]) > sortOption(array[j]))
                    {
                        Swap(array[i], array[j]);
                    }
                }
            }
            return array;
        }

        static int[][] SortDesc(int[][] array, Func<int[], int> sortOption)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sortOption(array[i]) < sortOption(array[j]))
                    {
                        Swap(array[i], array[j]);
                    }
                }
            }
            return array;
        }
    }
}
