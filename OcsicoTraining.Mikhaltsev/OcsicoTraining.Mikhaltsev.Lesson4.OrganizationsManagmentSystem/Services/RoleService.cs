using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

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

        public async Task CreateRoleAsync(Role role)
        {
            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveRoleAsync(Role role)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetAllAsync();
            var empOrgRoles = empOrgRolesAll.Where(e => e.RoleId == role.Id);

            foreach (var empOrgRole in empOrgRoles)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }

            await roleRepository.RemoveAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await roleRepository.UpdateAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Role>> GetAllRolesAsync() => await roleRepository.GetAllAsync();
    }
}
