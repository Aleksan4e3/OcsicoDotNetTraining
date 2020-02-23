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
        private readonly IEmployeeRoleRepository employeeRoleRepository;
        private readonly IDataContext dataContext;

        public RoleService(IRoleRepository roleRepository,
            IEmployeeRoleRepository employeeRoleRepository,
            IDataContext dataContext)
        {
            this.roleRepository = roleRepository;
            this.employeeRoleRepository = employeeRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Role> CreateAsync(string name)
        {
            var role = new Role { Name = name };

            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();

            return role;
        }

        public async Task RemoveAsync(Role role)
        {
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.RoleId == role.Id)
                .ToListAsync();

            employeeRoleRepository.RemoveRange(empOrgRoles);
            roleRepository.Remove(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            roleRepository.Update(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAsync() => await roleRepository.GetQuery().ToListAsync();
    }
}
