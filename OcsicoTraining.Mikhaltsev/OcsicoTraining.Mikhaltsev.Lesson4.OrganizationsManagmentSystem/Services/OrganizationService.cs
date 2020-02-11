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

        public void AddOrganization(int id, string name) => orgRepository.Add(new Organization { Id = id, Name = name });

        public List<Employee> GetEmployees(int organizationId)
        {
            var organizations = orgRepository.GetAll();
            var requestedOrganization = organizations.FirstOrDefault(o => o.Id == organizationId);
            if (requestedOrganization == null)
            {
                throw new Exception("Organization not found");
            }
            return requestedOrganization.Employees;
        }

        public void RemoveEmployee(int organizationId, Employee employee)
        {
            var organization = orgRepository.GetAll().FirstOrDefault(o => o.Id == organizationId);

            if (organization==null)
            {
                throw new ArgumentException("Organization with same Id is`t exist");
            }

            var employees = GetEmployees(organizationId);

            if (employees.Contains(employee))
            {
                _ = employees.Remove(employee);
            }

            organization.Employees = employees;
            orgRepository.Update(organization);
        }

        public void AddEmployee(int organizationId, Employee employee)
        {
            var organization = orgRepository.GetAll().FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                throw new ArgumentException("Organization with same Id is`t exist");
            }

            var employees = GetEmployees(organizationId);
            employees.Add(employee);
            organization.Employees = employees;
            orgRepository.Update(organization);
        }

        public void AssignNewRole(int organizationId, Employee employee, Role role)
        {
            var organization = orgRepository.GetAll().FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                throw new ArgumentException("Organization with same Id is`t exist");
            }

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
    }
}
