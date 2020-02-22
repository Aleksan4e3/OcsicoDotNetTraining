using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<Organization> AddOrganizationAsync(string name);
        Task AttachEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId);
        Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId);
        Task AssignNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
        Task<List<Employee>> GetEmployeesAsync(Guid organizationId);
    }
}