using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson2.GenericSortMethod;
using static OcsicoTraining.Mikhaltsev.Lesson2.RootPowerN.NewtonMethod;

namespace OcsicoTraining.Mikhaltsev.Lesson2.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            RunSortUsersTask();
            _ = Console.ReadKey();
        }

        private static void RunRootPowerNTask()
        {
            Console.WriteLine($"Calculated by Newton`s method: {CalculateRootPowerN(3, 28, 0.0000001)}");
            Console.WriteLine($"Calculated by Math.Pow: {Math.Pow(28, 1d / 3)}");
        }

        private static IEnumerable<User> CreateListUsers() => new List<User>()
        {
        };

        private static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} {user.Age}");
            }
        }
        private static void RunSortUsersTask()
        {
            var users = CreateListUsers();
            var sortedUsers = users.SortDesc();

            Console.WriteLine("Before sorting:");
            PrintUsers(users);

            Console.WriteLine("After sorting");
            PrintUsers(sortedUsers);
        }
    }
}
