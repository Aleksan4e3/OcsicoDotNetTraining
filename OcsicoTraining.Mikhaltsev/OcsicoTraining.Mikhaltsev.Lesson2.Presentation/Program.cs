using System;
using static OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN.NewtonMethod;

namespace OcsicoTraining.Mikhaltsev.Lesson2.Presentation
{
    internal class Program
    {
        private static void Main() => RunRootPowerNTask();

        private static void RunRootPowerNTask()
        {
            Console.WriteLine($"Calculated by Newton`s method: {CalculateRootPowerN(3, 28, 0.0000001)}");
            Console.WriteLine($"Calculated by Math.Pow: {Math.Pow(28, 1d / 3)}");
        }
    }
}
