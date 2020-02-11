using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class OrganizationService
    {
        private readonly IFileRepository<Organization> orgRepository;
        private readonly IFileRepository<Employee> empRepository;

        public OrganizationService(IFileRepository<Organization> orgRep, IFileRepository<Employee> empRep)
        {
            orgRepository = orgRep;
            empRepository = empRep;
        }

        public List<Employee> GetEmployees(Organization organization)
        {
            var organizations = orgRepository.GetAll();
            var requestedOrganization = organizations.FirstOrDefault(o => o.Id == organization.Id);
            if (requestedOrganization == null)
            {
                throw new Exception("Organization not found");
            }
            return requestedOrganization.Employees;
        }

        public void RemoveEmployee(Organization organization, Employee employee)
        {
            var employees = GetEmployees(organization);

            if (employees.Contains(employee))
            {
                _ = employees.Remove(employee);
            }

            organization.Employees = employees;
            orgRepository.Update(organization);
        }

        public void AddEmployee(Organization organization, Employee employee)
        {
            var employees = GetEmployees(organization);
            employees.Add(employee);
            organization.Employees = employees;
            orgRepository.Update(organization);
        }

        public void AssignNewRole(Organization organization, Employee employee, Role role)
        {
            var employees = GetEmployees(organization);
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
    }
}
