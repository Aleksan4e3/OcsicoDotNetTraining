using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRep) => roleRepository = roleRep;

        public async Task CreateRoleAsync(Role role) => await roleRepository.AddAsync(role);

        public async Task RemoveRoleAsync(Role role) => await roleRepository.RemoveAsync(role);

        public async Task UpdateRoleAsync(Role role) => await roleRepository.UpdateAsync(role);

        public async Task<List<Role>> GetAllRolesAsync() => await roleRepository.GetAllAsync();
    }
}
