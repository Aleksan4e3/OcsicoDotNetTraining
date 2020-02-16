using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson6.FibonacciNumbersGenerator
{
    public static class FibonacciNumbersGenerator
    {
        public static IEnumerable<int> Generate(int countOfNumbers)
        {
            if (countOfNumbers < 0)
            {
                throw new ArgumentException("Count of number must not be less than zero");
            }

            var firstNumber = 0;
            var secondNumber = 1;

            for (var i = 0; i < countOfNumbers; i++)
            {
                var current = firstNumber;

                firstNumber = secondNumber;
                secondNumber += current;

                yield return current;
            }
        }
    }
}
