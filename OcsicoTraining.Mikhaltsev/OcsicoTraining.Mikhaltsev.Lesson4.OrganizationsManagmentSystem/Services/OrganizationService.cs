using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService
    {
        private readonly IFileRepository<Organization> orgRepository;
        private readonly IFileRepository<EmployeeOrganizationRole> empOrgRepository;

        public OrganizationService(IFileRepository<Organization> orgRep, IFileRepository<EmployeeOrganizationRole> empOrgRep)
        {
            orgRepository = orgRep;
            empOrgRepository = empOrgRep;
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
            var organization = GetOrganizationById(organizationId);
            return organization.Employees;
        }

        public void RemoveEmployee(int organizationId, int employeeId)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);
            var employee = employees.FirstOrDefault(emp => emp.Id == employeeId);

            if (employee != null)
            {
                _ = employees.Remove(employee);
            }
            else
            {
                throw new ArgumentException($"Employee with Id = {employeeId} isn`t exist");
            }

            organization.Employees = employees;
            orgRepository.Update(organization);

            var empOrgRole = new EmployeeOrganizationRole { OrganizationId = organizationId, EmployeeId = employeeId };
            empOrgRepository.Remove(empOrgRole);
        }

        public void AddEmployee(int organizationId, Employee employee)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);

            if (employees.Contains(employee))
            {
                throw new ArgumentException("Employee already exist");
            }

            employees.Add(employee);
            organization.Employees = employees;
            orgRepository.Update(organization);
            empOrgRepository.Add(new EmployeeOrganizationRole { OrganizationId = organizationId, EmployeeId = employee.Id, Roles = employee.Roles });
        }

        public void AssignNewRole(int organizationId, int employeeId, int roleFrom, Role roleTo)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);
            var employee = employees.FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("This employee don`t work in this company");
            }

            var role = employee.Roles.FirstOrDefault(r => r.Id == roleFrom);

            if (role == null)
            {
                throw new ArgumentException("This employee doesn`t have this position");
            }

            _ = employee.Roles.Remove(role);
            employee.Roles.Add(roleTo);

            organization.Employees = employees;
            orgRepository.Update(organization);

            var empOrgRole = new EmployeeOrganizationRole
            {
                OrganizationId = organizationId,
                EmployeeId = employeeId,
                Roles = employee.Roles
            };
            empOrgRepository.Update(empOrgRole);
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
