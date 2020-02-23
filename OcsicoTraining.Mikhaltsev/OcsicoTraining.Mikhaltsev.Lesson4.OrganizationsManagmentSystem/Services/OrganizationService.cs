using System;
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
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeRoleRepository employeeRoleRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDataContext dataContext;

        public OrganizationService(IOrganizationRepository organizationRepository,
            IEmployeeRoleRepository employeeRoleRepository,
            IEmployeeRepository employeeRepository,
            IDataContext dataContext)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRoleRepository = employeeRoleRepository;
            this.employeeRepository = employeeRepository;
            this.dataContext = dataContext;
        }

        public async Task<Organization> CreateAsync(string name)
        {
            var organization = new Organization { Name = name };

            await organizationRepository.AddAsync(organization);
            await dataContext.SaveChangesAsync();

            return organization;
        }

        public async Task AttachEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = CreateEmployeeRole(organizationId, employeeId, roleId);

            await employeeRoleRepository.AddAsync(empOrgRole);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId)
        {
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId)
                .ToListAsync();

            employeeRoleRepository.RemoveRange(empOrgRoles);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync(Guid organizationId)
        {
            var employees = await employeeRepository
                .GetQuery()
                .Where(emp => emp.EmployeeRoles.Select(e => e.OrganizationId).Contains(organizationId))
                .ToListAsync();

            return employees.ToList();
        }

        public async Task AssignNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if (roleIdRemove != null)
            {
                var empOrgRoleRemove = CreateEmployeeRole(organizationId, employeeId, (Guid)roleIdRemove);

                employeeRoleRepository.Remove(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateEmployeeRole(organizationId, employeeId, roleIdAdd);

            await employeeRoleRepository.AddAsync(empOrgRoleAdd);
            await dataContext.SaveChangesAsync();
        }

        private EmployeeRole CreateEmployeeRole(Guid organizationId, Guid employeeId,
            Guid roleId) => new EmployeeRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };
    }
}
