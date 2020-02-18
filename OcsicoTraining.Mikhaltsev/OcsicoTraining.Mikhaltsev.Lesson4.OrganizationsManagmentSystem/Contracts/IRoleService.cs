using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task CreateRoleAsync(Role role);
        Task RemoveRole(Role role);
        Task UpdateRole(Role role);
        List<Role> GetAllRoles();
    }
}
