using System;
using System.Collections.Generic;
using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class FileRepository<T> : IFileRepository<T> where T : class, IEquatable<T>
    {
        private readonly ConnectionContext<T> context;

        public FileRepository() => context = new ConnectionContext<T>();
        public void Add(T entity)
        {
            var json = JsonSerializer.Serialize(entity);

            using (var sw = context.StreamAppendWriter)
            {
                sw.WriteLine(json);
            }
        }

        public List<T> GetAll()
        {
            var entities = new List<T>();
            using (var sr = context.StreamReader)
            {
                while (!sr.EndOfStream)
                {
                    var employee = JsonSerializer.Deserialize<T>(sr.ReadLine());
                    entities.Add(employee);
                }
            }

            return entities;
        }

        public void Remove(T entity)
        {
            var entities = GetAll();

            if (entities.Contains(entity))
            {
                _ = entities.Remove(entity);
            }

            using (var sw = context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    sw.WriteLine(json);
                }
            }
        }

        public void Update(T entity)
        {
            var entities = GetAll();

            if (entities.Contains(entity))
            {
                _ = entities.Remove(entity);
                entities.Add(entity);
            }

            using (var sw = context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    sw.WriteLine(json);
                }
            }
        }
    }
}
