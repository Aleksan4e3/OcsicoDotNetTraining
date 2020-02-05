using System;

namespace OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN
{
    public static class NewtonSoft
    {
        private static double MathPow(double number, int pow)
        {
            double result = 1;
            for (var i = 0; i < pow; i++)
            {
                result *= number;
            }

            return result;
        }

        public static double CalculateRootPowerN(double power, double number, double precision = 0.1)
        {
            var approximationOne = number / power;
            var approximationTwo = 1 / power * (((power - 1) * approximationOne) + (number / MathPow(approximationOne, (int)power - 1)));

            while (Math.Abs(approximationTwo - approximationOne) > precision)
            {
                approximationOne = approximationTwo;
                approximationTwo = 1 / power * (((power - 1) * approximationOne) + (number / MathPow(approximationOne, (int)power - 1)));
            }

            return approximationTwo;
        }
    }
}
