using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

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

        public async Task<CreateRoleViewModel> CreateAsync(CreateRoleViewModel model)
        {
            var role = new Role { Name = model.Name };

            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();

            return new CreateRoleViewModel { Name = role.Name };
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

        public async Task RemoveAsync(RoleViewModel roleViewModel)
        {
            var role = new Role { Id = roleViewModel.Id, Name = roleViewModel.Name };
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.RoleId == roleViewModel.Id)
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

        public async Task UpdateAsync(RoleViewModel roleViewModel)
        {
            var role = new Role { Id = roleViewModel.Id, Name = roleViewModel.Name };

            roleRepository.Update(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAsync() => await roleRepository.GetQuery().ToListAsync();

        public async Task<List<RoleViewModel>> GetAllAsync()
        {
            var roles = await GetAsync();

            return roles.Select(x => new RoleViewModel { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<Role> GetAsync(Guid id) =>
            await roleRepository.GetQuery().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<RoleViewModel> GetViewModelAsync(Guid id) =>
            await roleRepository.GetQuery()
                .Select(e => new RoleViewModel { Id = e.Id, Name = e.Name })
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<List<DropDownRoleViewModel>> GetRolesSelectListAsync()
        {
            var roles = await GetAsync();

            return roles.Select(x => new DropDownRoleViewModel { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}
