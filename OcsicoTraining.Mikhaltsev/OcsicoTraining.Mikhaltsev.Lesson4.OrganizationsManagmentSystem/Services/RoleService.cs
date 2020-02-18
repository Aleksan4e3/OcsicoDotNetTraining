using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRep) => roleRepository = roleRep;

        public void CreateRole(Role role) => roleRepository.AddAsync(role);

        public void RemoveRole(Role role) => roleRepository.RemoveAsync(role);

        public void UpdateRole(Role role) => roleRepository.UpdateAsync(role);

        public List<Role> GetAllRoles() => roleRepository.GetAll();
    }
}
