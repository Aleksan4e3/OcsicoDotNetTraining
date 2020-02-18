using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Task CreateEmployeeAsync(Employee employee);
        Task RemoveEmployee(Guid employeeId);
        Task UpdateEmployee(Employee employee);
    }
}
