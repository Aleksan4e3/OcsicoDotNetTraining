using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService
    {
        private readonly IFileRepository<Employee> empRepository;

        public EmployeeService(IFileRepository<Employee> empRep) => empRepository = empRep;

        public List<Employee> GetAllEmployees() => empRepository.GetAll();

        public Employee CreateEmployee(int id, string name, List<Role> roles)
        {
            var employee = new Employee {Id = id, Name = name, Roles = roles};
            empRepository.Add(employee);
            return employee;
        }

        public void RemoveEmployee(Employee employee) => empRepository.Remove(employee);

        public void UpdateEmployee(Employee employee) => empRepository.Update(employee);
    }
}
