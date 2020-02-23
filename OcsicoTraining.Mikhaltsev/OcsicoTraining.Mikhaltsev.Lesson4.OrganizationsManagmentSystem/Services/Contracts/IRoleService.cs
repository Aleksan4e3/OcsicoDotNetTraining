using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(string name);
        Task RemoveAsync(Role role);
        Task UpdateAsync(Role role);
        Task<List<Role>> GetAsync();
    }
}
