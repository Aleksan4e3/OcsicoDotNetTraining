using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task CreateRoleAsync(Role role);
        Task RemoveRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task<List<Role>> GetAllRolesAsync();
    }
}
