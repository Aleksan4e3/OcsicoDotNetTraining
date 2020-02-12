using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> empRepository;

        public EmployeeService(IRepository<Employee> empRep) => empRepository = empRep;

        public List<Employee> GetAllEmployees() => empRepository.GetAll();

        public Employee CreateEmployee(int id, string name, List<int> rolesId)
        {
            var employee = new Employee { Id = id, Name = name, RolesId = rolesId };
            empRepository.Add(employee);

            return employee;
        }

        public void RemoveEmployee(Employee employee) => empRepository.Remove(employee);

        public void UpdateEmployee(Employee employee) => empRepository.Update(employee);
    }
}
