using System;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class RoleRepository : MemoryBaseRepository<Role>, IRoleRepository
    {
        public override void Remove(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            base.Remove(entity);
        }

        public override void Update(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            base.Update(entity);
        }
    }
}
