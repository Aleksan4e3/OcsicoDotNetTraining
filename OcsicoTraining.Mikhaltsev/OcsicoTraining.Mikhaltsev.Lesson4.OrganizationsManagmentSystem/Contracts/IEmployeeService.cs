using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        void CreateEmployeeAsync(Employee employee);
        void RemoveEmployee(Guid employeeId);
        void UpdateEmployee(Employee employee);
    }
}
