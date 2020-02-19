using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IEmployeeRepository employeeRepository;

        public OrganizationService(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        public async Task<Organization> CreateOrganizationAsync(string name)
        {
            var organization = new Organization { Name = name };
            var organizations = await organizationRepository.GetAllAsync();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            await organizationRepository.AddAsync(organization);

            return organization;
        }

        public async Task<List<Employee>> GetEmployeesAsync(Guid organizationId)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetAllAsync();
            var empOrgRoles = empOrgRolesAll.FindAll(e => e.OrganizationId == organizationId);
            var employeesAll = await employeeRepository.GetAllAsync();
            var employees = employeesAll.FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public async Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetAllAsync();
            var empOrgRoles = empOrgRolesAll.FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }
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
