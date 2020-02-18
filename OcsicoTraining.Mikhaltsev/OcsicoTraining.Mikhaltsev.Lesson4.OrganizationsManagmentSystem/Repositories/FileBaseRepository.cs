using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public abstract class FileBaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ConnectionContext<T> Context;

        protected FileBaseRepository(string path) => Context = new ConnectionContext<T>(path);

        public async Task AddAsync(T entity)
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

        public abstract Task UpdateAsync(T entity);
        public abstract Task RemoveAsync(T entity);
    }
}
