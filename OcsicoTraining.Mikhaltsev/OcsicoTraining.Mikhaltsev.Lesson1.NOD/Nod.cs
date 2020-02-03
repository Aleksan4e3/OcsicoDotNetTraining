using System;

namespace OcsicoTraining.Mikhaltsev.Lesson1.NOD
{
    public static class Nod
    {
        public static int FindNOD(int number1, int number2)
        {
            while (number1 != 0)
            {
                int temp = number1;
                number1 = number2 % number1;
                number2 = temp;
            }

            return number2;
        }
    }
}
