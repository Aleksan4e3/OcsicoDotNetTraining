using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number a:");
            bool resultParseA = int.TryParse(Console.ReadLine(), out int a);
            Console.WriteLine("Enter number b:");
            bool resultParseB = int.TryParse(Console.ReadLine(), out int b);

            if (resultParseA && resultParseB)
            {
                int nod = FindNOD(a, b);
                Console.WriteLine($"For numbers a = {a} and b = {b} NOD = {nod}");
            }
            else
            {
                Console.WriteLine("Invalid values entered!!!");
            }
        }

        static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        static int FindNOD(int number1, int number2)
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
