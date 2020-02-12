using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService
    {
        private readonly IRepository<Organization> orgRepository;
        private readonly IRepository<EmployeeOrganizationRole> empOrgRepository;
        private readonly IRepository<Employee> empRepository;

        public OrganizationService(IRepository<Organization> orgRep, IRepository<Employee> empRep, IRepository<EmployeeOrganizationRole> empOrgRep)
        {
            orgRepository = orgRep;
            empRepository = empRep;
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
            var employeesId = organization.EmployeesId;
            return empRepository.GetAll().FindAll(emp => employeesId.Contains(emp.Id));
        }

        public void RemoveEmployee(int organizationId, int employeeId)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);
            var employee = employees.FirstOrDefault(emp => emp.Id == employeeId);

            if (employee != null)
            {
                _ = organization.EmployeesId.Remove(employeeId);
                _ = employee.CompaniesId.Remove(organizationId);
            }
            else
            {
                throw new ArgumentException($"Employee with Id = {employeeId} isn`t exist");
            }

            orgRepository.Update(organization);
            empRepository.Update(employee);
            empOrgRepository.Remove(new EmployeeOrganizationRole { OrganizationId = organizationId, EmployeeId = employeeId });
        }

        public void AddEmployee(int organizationId, Employee employee)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);

            if (employees.Contains(employee))
            {
                throw new ArgumentException("Employee already exist");
            }

            organization.EmployeesId.Add(employee.Id);
            employee.CompaniesId.Add(organizationId);
            orgRepository.Update(organization);
            empRepository.Update(employee);
            empOrgRepository.Add(new EmployeeOrganizationRole { OrganizationId = organizationId, EmployeeId = employee.Id, Roles = employee.RolesId });
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

            if (!employee.RolesId.Contains(roleFrom))
            {
                throw new ArgumentException("This employee doesn`t have this position");
            }

            _ = employee.RolesId.Remove(roleFrom);
            employee.RolesId.Add(roleTo.Id);
            empRepository.Update(employee);

            var empOrgRole = empOrgRepository.GetAll()
                .FirstOrDefault(e => e.EmployeeId == employeeId && e.OrganizationId == organizationId);

            _ = empOrgRole.Roles.Remove(roleFrom);
            empOrgRole.Roles.Add(roleTo.Id);
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
