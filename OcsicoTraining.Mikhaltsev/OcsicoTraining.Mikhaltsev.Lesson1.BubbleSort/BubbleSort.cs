using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort
{
    public static class BubbleSort
    {
        public static int GetSumElements(int[] array) => array.Sum();

        public static int GetMaxElement(int[] array) => array.Max();

        public static int GetMinElement(int[] array) => array.Min();

        public static void Swap(ref int[] a, ref int[] b) => (a, b) = (b, a);

        public static int[][] SortAsc(int[][] array, Func<int[], int> sortOption)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sortOption(array[i]) > sortOption(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }

        public static int[][] SortDesc(int[][] array, Func<int[], int> sortOption)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sortOption(array[i]) < sortOption(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }
    }
}
