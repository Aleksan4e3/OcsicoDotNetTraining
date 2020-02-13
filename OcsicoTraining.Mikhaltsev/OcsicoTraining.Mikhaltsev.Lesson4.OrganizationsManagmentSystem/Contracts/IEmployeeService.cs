using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee CreateEmployee(int id, string name);
        void RemoveEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
    }
}
