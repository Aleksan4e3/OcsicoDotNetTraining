using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Task<Organization> CreateOrganizationAsync(string name);
        List<Employee> GetEmployees(Guid organizationId);
        Task RemoveEmployee(Guid organizationId, Guid employeeId);
        Task AddEmployeeToOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId);
        Task AssignNewRole(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
