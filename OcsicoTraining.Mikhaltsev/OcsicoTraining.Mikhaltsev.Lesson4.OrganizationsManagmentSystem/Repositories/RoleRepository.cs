using System;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class RoleRepository : MemoryBaseRepository<Role>, IRoleRepository
    {
        public override void RemoveAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            base.RemoveAsync(entity);
        }

        public override void UpdateAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            base.UpdateAsync(entity);
        }
    }
}
