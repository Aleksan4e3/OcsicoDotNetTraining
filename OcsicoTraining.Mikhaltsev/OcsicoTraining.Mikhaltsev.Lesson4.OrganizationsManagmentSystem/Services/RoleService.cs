using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class RoleService
    {
        private readonly IRepository<Role> roleRepository;

        public RoleService() => roleRepository = new MemoryBaseRepository();

        public void AddRole(Role role) => roleRepository.Add(role);

        public void RemoveRole(Role role) => roleRepository.Remove(role);

        public void UpdateRole(Role role) => roleRepository.Update(role);

        public List<Role> GetAllRoles() => roleRepository.GetAll();
    }
}
