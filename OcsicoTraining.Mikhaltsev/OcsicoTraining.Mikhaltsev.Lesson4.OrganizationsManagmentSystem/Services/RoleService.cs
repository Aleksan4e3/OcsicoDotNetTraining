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

        public async Task CreateRoleAsync(Role role)
        {
            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveRoleAsync(Role role)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetQuery().ToListAsync();
            var empOrgRoles = empOrgRolesAll.Where(e => e.RoleId == role.Id);

            foreach (var empOrgRole in empOrgRoles)
            {
                employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }

            roleRepository.RemoveAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            roleRepository.UpdateAsync(role);
            await dataContext.SaveChangesAsync();
        }

        public IQueryable<Role> GetQuery() => roleRepository.GetQuery();
    }
}
