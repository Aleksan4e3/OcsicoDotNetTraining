﻿using System;
using OcsicoTraining.Mikhaltsev.Lesson1.NOD;
using static System.Console;

namespace OcsicoTraining.Mikhaltsev.Lesson1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter number a:");
            var resultParseA = int.TryParse(ReadLine(), out int a);
            WriteLine("Enter number b:");
            var resultParseB = int.TryParse(ReadLine(), out int b);

            if (resultParseA && resultParseB)
            {
                int nod = Nod.FindNOD(a, b);
                WriteLine($"For numbers a = {a} and b = {b} NOD = {nod}");
            }
            else
            {
                WriteLine("Invalid values entered!!!");
            }
        }
    }
}
