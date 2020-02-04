using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort
{
    public static class BubbleSort
    {
        public static int[][] Sort(int[][] array, Func<int[], int> sortOption, SortingDirection direction)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    (array[i], array[j]) = sortOption(array[i]) > sortOption(array[j]) ? (array[j], array[i]) : (array[i], array[j]);
                }
            }

            if (direction == SortingDirection.Ascending)
            {
                return array;
            }

            Array.Reverse(array);
            return array;
        }
    }
}
