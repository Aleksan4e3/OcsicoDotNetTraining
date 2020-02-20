using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDataContext dataContext;

        public OrganizationService(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository, IDataContext dataContext)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Organization> CreateOrganizationAsync(string name)
        {
            var organization = new Organization { Name = name };
            var organizations = await organizationRepository.GetQuery().ToListAsync();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            await organizationRepository.AddAsync(organization);
            await dataContext.SaveChangesAsync();

            return organization;
        }

        public async Task<List<Employee>> GetEmployeesAsync(Guid organizationId)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetQuery().ToListAsync();
            var empOrgRoles = empOrgRolesAll.Where(e => e.OrganizationId == organizationId);
            var employeesAll = await employeeRepository.GetQuery().ToListAsync();
            var employees = employeesAll.Where(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees.ToList();
        }

        public async Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetQuery().ToListAsync();
            var empOrgRoles = empOrgRolesAll.Where(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }

            await dataContext.SaveChangesAsync();
        }

        public async Task AddEmployeeToOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            await employeeOrganizationRoleRepository.AddAsync(empOrgRole);
            await dataContext.SaveChangesAsync();
        }

        public async Task AssignNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if (roleIdRemove != null)
            {
                var empOrgRoleRemove = CreateEmployeeOrganizationRole(organizationId, employeeId, (Guid)roleIdRemove);

                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateEmployeeOrganizationRole(organizationId, employeeId, roleIdAdd);

            await employeeOrganizationRoleRepository.AddAsync(empOrgRoleAdd);
            await dataContext.SaveChangesAsync();
        }

        private EmployeeOrganizationRole CreateEmployeeOrganizationRole(Guid organizationId, Guid employeeId,
            Guid roleId) => new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };
    }
}
