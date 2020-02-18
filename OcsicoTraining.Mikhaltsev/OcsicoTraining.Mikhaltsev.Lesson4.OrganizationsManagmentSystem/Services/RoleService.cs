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

        public Task RemoveRole(Role role) => roleRepository.RemoveAsync(role);

        public Task UpdateRole(Role role) => roleRepository.UpdateAsync(role);

        public List<Role> GetAllRoles() => roleRepository.GetAll();
    }
}
