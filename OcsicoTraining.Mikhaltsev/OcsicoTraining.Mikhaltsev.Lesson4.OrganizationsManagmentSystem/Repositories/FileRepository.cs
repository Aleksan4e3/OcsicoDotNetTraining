using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class FileRepository : IFileRepository<Employee>
    {
        private readonly EmployeeConnectionContext context;

        public FileRepository() => context = new EmployeeConnectionContext();
        public void Add(Employee entity)
        {
            var json = JsonSerializer.Serialize(entity);

            using (var sw = context.StreamAppendWriter)
            {
                sw.WriteLine(json);
            }
        }

        public IList<Employee> GetAll()
        {
            var employees = new List<Employee>();
            using (var sr = context.StreamReader)
            {
                while (!sr.EndOfStream)
                {
                    var employee = JsonSerializer.Deserialize<Employee>(sr.ReadLine());
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public void Remove(Employee entity)
        {
            using (var sw = context.StreamReWriter)
            {
                var employees = GetAll();
                for (var i = 0; i < employees.Count; i++)
                {
                    if (employees[i].Id != entity.Id)
                    {
                        var json = JsonSerializer.Serialize(employees[i]);
                        sw.WriteLine(json);
                    }
                }
            }
        }

        public void Update(Employee entity)
        {
            using (var sw = context.StreamReWriter)
            {
                var employees = GetAll();
                for (var i = 0; i < employees.Count; i++)
                {
                    if (employees[i].Id == entity.Id)
                    {
                        employees[i] = entity;
                    }

                    var json = JsonSerializer.Serialize(employees[i]);
                    sw.WriteLine(json);
                }
            }
        }
    }
}
