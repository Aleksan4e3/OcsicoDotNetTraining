using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Task<Organization> CreateOrganizationAsync(string name);
        Task<List<Employee>> GetEmployeesAsync(Guid organizationId);
        Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId);
        Task AddEmployeeToOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId);
        Task AssignNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
