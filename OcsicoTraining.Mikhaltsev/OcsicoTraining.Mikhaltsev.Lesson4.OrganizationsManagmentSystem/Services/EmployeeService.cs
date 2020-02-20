using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IDataContext dataContext;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository, IDataContext dataContext)
        {
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<IQueryable<Employee>> GetAllEmployeesAsync() => await employeeRepository.GetAllAsync();

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveEmployeeAsync(Guid employeeId)
        {
            var empOrgRolesAll = await employeeOrganizationRoleRepository.GetAllAsync();
            var empOrgRoles = empOrgRolesAll.Where(e => e.EmployeeId == employeeId);

            foreach (var empOrgRole in empOrgRoles)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRole);
            }

            var employees = await GetAllEmployeesAsync();
            var employee = employees.FirstOrDefault(emp => emp.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee with the same Id doesn`t exist");
            }

            await employeeRepository.RemoveAsync(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await employeeRepository.UpdateAsync(employee);
            await dataContext.SaveChangesAsync();
        }
    }
}
