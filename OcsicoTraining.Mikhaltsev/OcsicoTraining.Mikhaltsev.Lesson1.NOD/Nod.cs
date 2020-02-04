using System;

namespace OcsicoTraining.Mikhaltsev.Lesson1.NOD
{
    public static class Nod
    {
        public static int FindNOD(int firstNumber, int secondNumber)
        {
            while (firstNumber != 0)
            {
                int temp = firstNumber;
                firstNumber = secondNumber % firstNumber;
                secondNumber = temp;
            }

            return secondNumber;
        }
    }
}
