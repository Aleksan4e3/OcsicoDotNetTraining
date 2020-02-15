using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository empRepository;
        private readonly IEmployeeOrganizationRoleRepository empOrgRepository;

        public EmployeeService(IEmployeeRepository empRep, IEmployeeOrganizationRoleRepository empOrgRep)
        {
            empRepository = empRep;
            empOrgRepository = empOrgRep;
        }

        public List<Employee> GetAllEmployees() => empRepository.GetAll();

        public void CreateEmployee(Employee employee) => empRepository.Add(employee);

        public void RemoveEmployee(Guid employeeId)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee with the same Id doesn`t exist");
            }

            empRepository.Remove(employee);

            var empOrgRoles = empOrgRepository.GetAll().FindAll(e => e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                empOrgRepository.Remove(empOrgRole);
            }

        }

        public void UpdateEmployee(Employee employee) => empRepository.Update(employee);
    }
}
