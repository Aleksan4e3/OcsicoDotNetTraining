using System;
using OcsicoTraining.Mikhaltsev.Lesson2.GenericQueue;
using static OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN.NewtonMethod;

namespace OcsicoTraining.Mikhaltsev.Lesson2.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            RunQueueTask();
            _ = Console.ReadKey();
        }

        private static void RunRootPowerNTask()
        {
            Console.WriteLine($"Calculated by Newton`s method: {CalculateRootPowerN(3, 28, 0.0000001)}");
            Console.WriteLine($"Calculated by Math.Pow: {Math.Pow(28, 1d / 3)}");
        }

        private static void RunQueueTask()
        {
            var queue = new Queue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            _ = queue.Dequeue();
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine($"First element in Queue: {queue.Peek()}");
            Console.WriteLine($"Count: {queue.Count}");
        }
    }
}
