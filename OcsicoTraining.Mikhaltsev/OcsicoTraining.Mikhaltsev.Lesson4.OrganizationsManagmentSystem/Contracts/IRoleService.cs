using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRoleService
    {
        void CreateRoleAsync(Role role);
        void RemoveRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetAllRoles();
    }
}
