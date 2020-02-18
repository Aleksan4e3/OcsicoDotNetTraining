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

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        public List<Employee> GetAllEmployees() => employeeRepository.GetAll();

        public async void CreateEmployeeAsync(Employee employee) => await employeeRepository.AddAsync(employee);

        public void RemoveEmployee(Guid employeeId)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee with the same Id doesn`t exist");
            }

            employeeRepository.RemoveAsync(employee);

            var empOrgRoles = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }

        }

        public void UpdateEmployee(Employee employee) => employeeRepository.UpdateAsync(employee);
    }
}
