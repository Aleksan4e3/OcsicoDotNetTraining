using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts
{
    public interface IRoleService
    {
        Task<Role> AddRoleAsync(string name);
        Task RemoveRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task<List<Role>> GetRolesAsync();
    }
}
