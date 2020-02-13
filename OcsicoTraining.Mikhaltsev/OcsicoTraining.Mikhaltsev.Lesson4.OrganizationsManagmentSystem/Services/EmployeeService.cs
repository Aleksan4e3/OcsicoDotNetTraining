using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> empRepository;
        private readonly IRepository<Organization> orgRepository;
        private readonly IRepository<EmployeeOrganizationRole> empOrgRepository;

        public EmployeeService(IRepository<Employee> empRep, IRepository<Organization> orgRep, IRepository<EmployeeOrganizationRole> empOrgRep)
        {
            empRepository = empRep;
            orgRepository = orgRep;
            empOrgRepository = empOrgRep;
        }

        public List<Employee> GetAllEmployees() => empRepository.GetAll();

        public Employee CreateEmployee(int id, string name)
        {
            var employee = new Employee { Id = id, Name = name };
            empRepository.Add(employee);

            return employee;
        }

        public void RemoveEmployee(int employeeId)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee with the same Id doesn`t exist");
            }

            empRepository.Remove(employee);

            var organizations = orgRepository.GetAll().FindAll(org => org.EmployeesId.Contains(employeeId));

            if (organizations.Count != 0)
            {
                foreach (var organization in organizations)
                {
                    _ = organization.EmployeesId.Remove(employeeId);
                    orgRepository.Update(organization);
                }
            }

            var empOrgRoles = empOrgRepository.GetAll().FindAll(e => e.EmployeeId == employeeId);

            if (empOrgRoles.Count != 0)
            {
                foreach (var e in empOrgRoles)
                {
                    empOrgRepository.Remove(e);
                }
            }
        }

        public void UpdateEmployee(Employee employee) => empRepository.Update(employee);
    }
}
