using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson1.BubbleSort
{
    public static class BubbleSort
    {
        public static int[][] Sort(int[][] array, Func<int[], int[], bool> sortOption)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (sortOption(array[i], array[j]))
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }

            return array;
        }
    }
}
