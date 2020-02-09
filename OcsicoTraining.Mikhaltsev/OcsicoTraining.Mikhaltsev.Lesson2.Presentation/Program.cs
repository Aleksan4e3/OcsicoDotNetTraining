using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson2.GenericSortMethod;
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

        private static IEnumerable<User> CreateListUsers() => new List<User>()
        {
            new User() {Name = "Alex", Age = 29},
            null,
            new User() {Name = "Ivan", Age = 22},
            new User() {Name = "Sergei", Age = 28},
            new User() {Name = "Andrew", Age = 30},
        };

        private static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user?.Name} {user?.Age}");
            }
        }
        private static void RunSortUsersTask()
        {
            var users = CreateListUsers();
            var sortedUsers = users.SortAsc();

            Console.WriteLine("Before sorting:");
            PrintUsers(users);

            Console.WriteLine("After sorting");
            PrintUsers(sortedUsers);
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
