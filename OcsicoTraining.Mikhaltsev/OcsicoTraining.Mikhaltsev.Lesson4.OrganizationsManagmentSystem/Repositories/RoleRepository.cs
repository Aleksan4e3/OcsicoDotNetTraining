using System;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class RoleRepository : MemoryBaseRepository<Role>//, IRoleRepository
    {
        public override async Task RemoveAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            await base.RemoveAsync(entity);
        }

        public override async Task UpdateAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity does not exist");
            }

            await base.UpdateAsync(entity);
        }
    }
}
