using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        void AddOrganization(int id, string name);
        List<Employee> GetEmployees(int organizationId);
        void RemoveEmployee(int organizationId, int employeeId);
        void AddEmployee(int organizationId, Employee employee, int roleId);
        void AssignNewRole(int organizationId, int employeeId, int roleAdd, int roleRemove = 0);
    }
}
