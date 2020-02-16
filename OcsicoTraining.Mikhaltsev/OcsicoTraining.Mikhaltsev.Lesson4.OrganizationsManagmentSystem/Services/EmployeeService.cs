using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;

        public EmployeeService(IEmployeeRepository empRep, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRep)
        {
            employeeRepository = empRep;
            employeeOrganizationRoleRepository = employeeOrganizationRoleRep;
        }

        public List<Employee> GetAllEmployees() => employeeRepository.GetAll();

        public void CreateEmployee(Employee employee) => employeeRepository.Add(employee);

        public void RemoveEmployee(Guid employeeId)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee with the same Id doesn`t exist");
            }

            employeeRepository.Remove(employee);

            var empOrgRoles = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                employeeOrganizationRoleRepository.Remove(empOrgRole);
            }

        }

        public void UpdateEmployee(Employee employee) => employeeRepository.Update(employee);
    }
}
