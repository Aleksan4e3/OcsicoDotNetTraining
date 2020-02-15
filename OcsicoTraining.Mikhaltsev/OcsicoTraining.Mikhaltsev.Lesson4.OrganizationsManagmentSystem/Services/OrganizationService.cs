using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository orgRepository;
        private readonly IEmployeeOrganizationRoleRepository empOrgRoleRepository;
        private readonly IEmployeeRepository empRepository;

        public OrganizationService(IOrganizationRepository orgRep, IEmployeeRepository empRep, IEmployeeOrganizationRoleRepository empOrgRoleRep)
        {
            orgRepository = orgRep;
            empRepository = empRep;
            empOrgRoleRepository = empOrgRoleRep;
        }

        public Organization CreateOrganization(string name)
        {
            var organization = new Organization { Name = name };
            var organizations = orgRepository.GetAll();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            orgRepository.Add(organization);

            return organization;
        }

        public List<Employee> GetEmployees(Guid organizationId)
        {
            var empOrgRoles = empOrgRoleRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = empRepository.GetAll()
                .FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public void RemoveEmployee(Guid organizationId, Guid employeeId)
        {
            var empOrgRoles = empOrgRoleRepository.GetAll()
                .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                empOrgRoleRepository.Remove(empOrgRole);
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

            empOrgRoleRepository.Add(empOrgRole);
        }

        // if roleRemove = 0 new position is added to the employee
        public void AssignNewRole(Guid organizationId, Guid employeeId, Guid roleAdd, Guid roleRemove = default)
        {
            if (roleRemove == default)
            {
                var empOrgRoleRemove = new EmployeeOrganizationRole
                {
                    EmployeeId = employeeId,
                    OrganizationId = organizationId,
                    RoleId = roleRemove
                };

                empOrgRoleRepository.Remove(empOrgRoleRemove);
            }

            var empOrgRoleAdd = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleAdd
            };

            empOrgRoleRepository.Add(empOrgRoleAdd);
        }
    }
}
