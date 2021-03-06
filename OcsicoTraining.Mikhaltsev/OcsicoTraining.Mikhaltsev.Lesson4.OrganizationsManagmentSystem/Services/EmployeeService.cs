using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeRoleRepository employeeRoleRepository;
        private readonly IDataContext dataContext;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IEmployeeRoleRepository employeeRoleRepository,
            IDataContext dataContext)
        {
            this.employeeRepository = employeeRepository;
            this.employeeRoleRepository = employeeRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Employee> CreateAsync(string name)
        {
            var employee = new Employee { Name = name };

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();

            return employee;
        }

        public async Task<CreateEmployeeViewModel> CreateAsync(CreateEmployeeViewModel model)
        {
            var employee = new Employee { Name = model.Name };

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();

            return new CreateEmployeeViewModel { Name = model.Name };
        }

        public async Task RemoveAsync(Employee employee)
        {
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.EmployeeId == employee.Id)
                .ToListAsync();

            employeeRoleRepository.RemoveRange(empOrgRoles);
            employeeRepository.Remove(employee);

            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee { Id = employeeViewModel.Id, Name = employeeViewModel.Name };
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.EmployeeId == employeeViewModel.Id)
                .ToListAsync();

            employeeRoleRepository.RemoveRange(empOrgRoles);
            employeeRepository.Remove(employee);

            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee { Id = employeeViewModel.Id, Name = employeeViewModel.Name };

            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAsync() => await employeeRepository.GetQuery().ToListAsync();

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await GetAsync();

            return employees.Select(x => new EmployeeViewModel { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<Employee> GetAsync(Guid id) =>
            await employeeRepository.GetQuery().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<EmployeeViewModel> GetViewModelAsync(Guid id) =>
            await employeeRepository
                .GetQuery()
                .Select(e => new EmployeeViewModel { Id = e.Id, Name = e.Name })
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<List<DropDownViewModel>> GetEmployeesSelectList()
        {
            var employees = await GetAsync();

            return employees.Select(x => new DropDownViewModel { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<List<EmployeeViewModel>> SearchAsync(string name) =>
            await employeeRepository
                .GetQuery()
                .Where(x => x.Name.Contains(name))
                .Select(x => new EmployeeViewModel { Id = x.Id, Name = x.Name })
                .ToListAsync();
    }
}
