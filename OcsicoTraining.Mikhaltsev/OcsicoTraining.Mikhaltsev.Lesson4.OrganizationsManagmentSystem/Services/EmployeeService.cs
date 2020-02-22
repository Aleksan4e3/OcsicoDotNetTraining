using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeRoleRepository employeeRoleRepository;
        private readonly IDataContext dataContext;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeRoleRepository employeeRoleRepository, IDataContext dataContext)
        {
            this.employeeRepository = employeeRepository;
            this.employeeRoleRepository = employeeRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Employee> AddEmployeeAsync(string name)
        {
            var employee = new Employee { Name = name };

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();

            return employee;
        }

        public async Task RemoveEmployeeAsync(Employee employee)
        {
            var empOrgRoles = await employeeRoleRepository
                .GetQuery()
                .Where(e => e.EmployeeId == employee.Id)
                .ToListAsync();

            employeeRoleRepository.RemoveRange(empOrgRoles);
            employeeRepository.Remove(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync() => await employeeRepository.GetQuery().ToListAsync();
    }
}
