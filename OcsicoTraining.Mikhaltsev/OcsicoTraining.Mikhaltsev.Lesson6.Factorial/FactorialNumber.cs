using System;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Factorial
{
    public static class FactorialNumber
    {
        public static int ComputeFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must not be less than zero");
            }

            return number == 0 ? 1 : number * ComputeFactorial(number - 1);
        }
    }
}
