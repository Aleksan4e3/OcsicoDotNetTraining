using System;

namespace OcsicoTraining.Mikhaltsev.Lesson1.NOD
{
    public static class Nod
    {
        static void Swap(ref int number1, ref int number2)
        {
            (number1, number2) = (number2, number1);
        }

        public static int FindNOD(int number1, int number2)
        {
            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if (number1 < number2)
            {
                Swap(ref number1, ref number2);
            }

            int nextNumber = 1;

            while (nextNumber != 0)
            {
                nextNumber = number1 % number2;
                number1 = number2;
                number2 = nextNumber;
            }

            return number1;
        }
    }
}
