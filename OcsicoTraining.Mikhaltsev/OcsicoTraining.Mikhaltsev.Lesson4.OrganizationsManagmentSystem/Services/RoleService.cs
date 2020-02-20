using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IDataContext dataContext;

        public RoleService(IRoleRepository roleRep, IDataContext dataContext)
        {
            roleRepository = roleRep;
            this.dataContext = dataContext;
        }

        public async Task CreateRoleAsync(Role role)
        {
            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveRoleAsync(Role role)
        {
            await roleRepository.RemoveAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await roleRepository.UpdateAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Role>> GetAllRolesAsync() => await roleRepository.GetAllAsync();
    }
}
