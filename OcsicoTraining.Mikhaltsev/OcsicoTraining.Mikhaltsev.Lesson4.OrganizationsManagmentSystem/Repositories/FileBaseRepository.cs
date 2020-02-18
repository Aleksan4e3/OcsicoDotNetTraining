using System.Collections.Generic;
using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public abstract class FileBaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ConnectionContext<T> Context;

        protected FileBaseRepository(string path) => Context = new ConnectionContext<T>(path);

        public async void Add(T entity)
        {
            var json = JsonSerializer.Serialize(entity);

            using (var sw = Context.StreamAppendWriter)
            {
                await sw.WriteLineAsync(json);
            }
        }

        public List<T> GetAll()
        {
            var entities = new List<T>();

            using (var sr = Context.StreamReader)
            {
                while (!sr.EndOfStream)
                {
                    var employee = JsonSerializer.Deserialize<T>(sr.ReadLine());
                    entities.Add(employee);
                }
            }

            return entities;
        }

        public abstract void Update(T entity);
        public abstract void Remove(T entity);
    }
}
