using System;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IEmployeeService
    {
        Task<IQueryable<Employee>> GetAllEmployeesAsync();
        Task CreateEmployeeAsync(Employee employee);
        Task RemoveEmployeeAsync(Guid employeeId);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
