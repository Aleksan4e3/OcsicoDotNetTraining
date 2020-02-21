using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static async Task Main()
        {
            await RunApplication();
        }

        private static async Task RunApplication()
        {
            var serviceProvider = Application.GetServiceProvider();

            var organizationService = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var roleService = serviceProvider.GetService<IRoleService>();

            var orgOcsico = await organizationService.AddOrganizationAsync("Ocsico");
            var orgMicrosoft = await organizationService.AddOrganizationAsync("Microsoft");
            var orgEpam = await organizationService.AddOrganizationAsync("ScienceSoft");

            var developerRole = await roleService.AddRoleAsync("Developer");
            var qaRole = await roleService.AddRoleAsync("QA");
            var managerRole = await roleService.AddRoleAsync("Manager");
            var leadRole = await roleService.AddRoleAsync("Lead");

            var employeeAlex = await employeeService.AddEmployeeAsync("Alex");
            var employeeIvan = await employeeService.AddEmployeeAsync("Ivan");
            var employeeVadim = await employeeService.AddEmployeeAsync("Vadim");
            var employeeAndrew = await employeeService.AddEmployeeAsync("Andrew");

            await organizationService.AddEmployeeAsync(orgOcsico.Id, employeeAlex.Id, developerRole.Id);
            await organizationService.AddEmployeeAsync(orgOcsico.Id, employeeIvan.Id, developerRole.Id);
            await organizationService.AddEmployeeAsync(orgEpam.Id, employeeIvan.Id, developerRole.Id);
            await organizationService.AddEmployeeAsync(orgEpam.Id, employeeAndrew.Id, leadRole.Id);
            await organizationService.AddEmployeeAsync(orgMicrosoft.Id, employeeVadim.Id, managerRole.Id);

            await organizationService.AssignNewRoleAsync(orgMicrosoft.Id, employeeVadim.Id, developerRole.Id, null);

            employeeIvan.Name = "UpdateIvan";
            await employeeService.UpdateEmployeeAsync(employeeIvan);

            await employeeService.RemoveEmployeeAsync(employeeAlex);
            await roleService.RemoveRoleAsync(qaRole);
            await organizationService.RemoveEmployeeAsync(orgEpam.Id, employeeIvan.Id);

            Console.WriteLine("All Employees:");

            var allEmployees = await employeeService.GetEmployeesAsync();

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"Employee: {employee.Id} {employee.Name}");

                foreach (var employeeEmployeeOrganizationRole in employee.EmployeeOrganizationRoles)
                {
                    Console.WriteLine($"Company: {employeeEmployeeOrganizationRole.Organization.Name}, Role: {employeeEmployeeOrganizationRole.Role.Name}");
                }

                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
