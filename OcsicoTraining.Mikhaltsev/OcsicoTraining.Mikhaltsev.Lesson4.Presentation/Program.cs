using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static void Main() => Initialize();

        private static void Initialize()
        {
            var memrep = new MemoryRepository();
            var role1 = new Role {Id = 2, Name = "Manager"};
            memrep.Add(new Role { Id = 1, Name = "QA" });
            memrep.Add(role1);
            memrep.Add(new Role { Id = 3, Name = "Developer" });
            role1.Name = "Test";
            //memrep.Remove(role1);
            memrep.Update(role1);

            var result = memrep.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }

    }
}
