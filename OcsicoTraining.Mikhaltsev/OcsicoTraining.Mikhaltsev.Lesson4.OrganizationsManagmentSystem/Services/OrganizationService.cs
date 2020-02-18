using System;
using System.Collections.Generic;
using System.Linq;
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

        public Organization CreateOrganization(string name)
        {
            var organization = new Organization { Name = name };
            var organizations = organizationRepository.GetAll();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            organizationRepository.Add(organization);

            return organization;
        }

        public List<Employee> GetEmployees(Guid organizationId)
        {
            var empOrgRoles = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = employeeRepository.GetAll()
                .FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public void RemoveEmployee(Guid organizationId, Guid employeeId)
        {
            var empOrgRoles = employeeOrganizationRoleRepository.GetAll()
                .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                employeeOrganizationRoleRepository.Remove(empOrgRole);
            }
        }

        public void AddEmployeeToOrganization(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            employeeOrganizationRoleRepository.Add(empOrgRole);
        }

        public void AssignNewRole(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if (roleIdRemove != null)
            {
                var empOrgRoleRemove = CreateEmployeeOrganizationRole(organizationId, employeeId, (Guid)roleIdRemove);

                employeeOrganizationRoleRepository.Remove(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateEmployeeOrganizationRole(organizationId, employeeId, roleIdAdd);

            employeeOrganizationRoleRepository.Add(empOrgRoleAdd);
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
