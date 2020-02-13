using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public abstract class MemoryBaseRepository<T> : IRepository<T> where T : class, IEquatable<T>
    {
        private readonly List<T> entities;

        protected MemoryBaseRepository() => entities = new List<T>();

        public void Add(T entity) => entities.Add(entity);

        public List<T> GetAll() => entities;

        public void Remove(T entity) => entities.Remove(entity);

        public void Update(T entity)
        {
            if (!entities.Contains(entity))
            {
                throw new ArgumentException("Entity does not exist");
            }

            _ = entities.Remove(entity);
            entities.Add(entity);
        }
    }
}
