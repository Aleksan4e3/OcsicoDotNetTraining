using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Organization CreateOrganization(string name);
        List<Employee> GetEmployees(Guid organizationId);
        void RemoveEmployee(Guid organizationId, Guid employeeId);
        void AddEmployeeToOrganization(Guid organizationId, Guid employeeId, Guid roleId);
        void AssignNewRole(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
