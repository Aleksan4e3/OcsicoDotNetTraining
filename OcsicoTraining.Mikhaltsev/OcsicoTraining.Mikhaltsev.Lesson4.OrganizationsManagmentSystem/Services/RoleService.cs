using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IDataContext dataContext;

        public RoleService(IRoleRepository roleRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository, IDataContext dataContext)
        {
            this.roleRepository = roleRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Role> AddRoleAsync(string name)
        {
            var role = new Role { Name = name };

            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();

            return role;
        }

        public async Task RemoveRoleAsync(Role role)
        {
            var empOrgRoles = await employeeOrganizationRoleRepository
                .GetQuery()
                .Where(e => e.RoleId == role.Id)
                .ToListAsync();

            employeeOrganizationRoleRepository.RemoveRange(empOrgRoles);
            roleRepository.Remove(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            roleRepository.Update(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRolesAsync() => await roleRepository.GetQuery().ToListAsync();
    }
}
