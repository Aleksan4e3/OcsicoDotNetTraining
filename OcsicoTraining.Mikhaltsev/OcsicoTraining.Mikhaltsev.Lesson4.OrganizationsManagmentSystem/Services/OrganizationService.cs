using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService
    {
        private readonly IFileRepository<Organization> orgRepository;

        public OrganizationService(IFileRepository<Organization> orgRep) => orgRepository = orgRep;

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
        }

        public void AssignNewRole(int organizationId, Employee employee, Role role)
        {
            var organization = GetOrganizationById(organizationId);
            var employees = GetEmployees(organizationId);

            for (var i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employee.Id)
                {
                    //What was the role in the company???.....
                    employees[i].Roles.Add(role);
                }
            }

            organization.Employees = employees;
            orgRepository.Update(organization);
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
