using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.FibonacciGenerator
{
    public static class FibonacciGenerator
    {
        public static IEnumerable<int> Generate(int countOfNumbers)
        {
            if (countOfNumbers < 0)
            {
                throw new ArgumentException("Count of number must not be less than zero");
            }

            var a = 0;
            var b = 1;

            for (var i = 0; i < countOfNumbers; i++)
            {
                var current = a;

                a = b;
                b += current;

                yield return current;
            }
        }
    }
}
