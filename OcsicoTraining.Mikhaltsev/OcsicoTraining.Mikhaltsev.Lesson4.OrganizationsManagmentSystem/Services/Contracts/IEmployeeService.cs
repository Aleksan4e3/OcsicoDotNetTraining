using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(string name);
        Task RemoveEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task<List<Employee>> GetEmployeesAsync();
    }
}
