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

        public void AddOrganization(int id, string name)
        {
            var organization = new Organization { Id = id, Name = name };
            var organizations = orgRepository.GetAll();

            if (organizations.Contains(organization))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            orgRepository.Add(organization);
        }

        public List<Employee> GetEmployees(int organizationId)
        {
            var empOrgRoles = empOrgRoleRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = empRepository.GetAll()
                .FindAll(emp => empOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));

            return employees;
        }

        public void RemoveEmployee(int organizationId, int employeeId)
        {
            var empOrgRoles = empOrgRoleRepository.GetAll()
                .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                empOrgRoleRepository.Remove(empOrgRole);
            }
        }

        public void AddEmployee(int organizationId, Employee employee, int roleId)
        {
            var empOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employee.Id,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            empOrgRoleRepository.Add(empOrgRole);
        }

        // if roleRemove = 0 new position is added to the employee
        public void AssignNewRole(int organizationId, int employeeId, int roleAdd, int roleRemove = 0)
        {
            if (roleRemove != 0)
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

        private Organization GetOrganizationById(int organizationId)
        {
            var organization = orgRepository.GetAll().FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                throw new ArgumentException("Organization with same Id is`t exist");
            }

            return organization;
        }
    }
}
