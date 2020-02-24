using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(string name);
        Task<CreateEmployeeViewModel> CreateAsync(CreateEmployeeViewModel model);
        Task RemoveAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetAsync(Guid id);
    }
}
