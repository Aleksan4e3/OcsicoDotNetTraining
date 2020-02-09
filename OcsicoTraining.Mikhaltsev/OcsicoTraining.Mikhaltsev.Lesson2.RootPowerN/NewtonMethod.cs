using System;

namespace OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN
{
    public static class NewtonMethod
    {
        public static double CalculateRootPowerN(int power, double number, double precision = 0.1)
        {
            if (power <= 1)
            {
                throw new PowerArgumentException("The root power should be greater than 1");
            }

            if (precision <= 0)
            {
                throw new PrecisionArgumentException("The precision should be positive");
            }

            if (number < 0 && power % 2 == 0)
            {
                throw new NumberArgumentException("When number is negative, root power should be odd");
            }

            var approximationOne = number / power;
            double approximationTwo, currentPrecision;

            do
            {
                approximationTwo = 1d / power * (((power - 1) * approximationOne) + (number / Math.Pow(approximationOne, power - 1)));
                currentPrecision = Math.Abs(approximationTwo - approximationOne);
                approximationOne = approximationTwo;
            } while (currentPrecision > precision);

            return approximationTwo;
        }
    }
}
