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
            var serviceProvider = DependencyResolver.GetServiceProvider();

            var organizationService = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var roleService = serviceProvider.GetService<IRoleService>();

            var orgOcsico = await organizationService.CreateAsync("Ocsico");
            var orgMicrosoft = await organizationService.CreateAsync("Microsoft");
            var orgEpam = await organizationService.CreateAsync("ScienceSoft");

            var developerRole = await roleService.CreateAsync("Developer");
            var qaRole = await roleService.CreateAsync("QA");
            var managerRole = await roleService.CreateAsync("Manager");
            var leadRole = await roleService.CreateAsync("Lead");

            var employeeAlex = await employeeService.CreateAsync("Alex");
            var employeeIvan = await employeeService.CreateAsync("Ivan");
            var employeeVadim = await employeeService.CreateAsync("Vadim");
            var employeeAndrew = await employeeService.CreateAsync("Andrew");

            await organizationService.AttachEmployeeAsync(orgOcsico.Id, employeeAlex.Id, developerRole.Id);
            await organizationService.AttachEmployeeAsync(orgOcsico.Id, employeeIvan.Id, developerRole.Id);
            await organizationService.AttachEmployeeAsync(orgEpam.Id, employeeIvan.Id, developerRole.Id);
            await organizationService.AttachEmployeeAsync(orgEpam.Id, employeeAndrew.Id, leadRole.Id);
            await organizationService.AttachEmployeeAsync(orgMicrosoft.Id, employeeVadim.Id, managerRole.Id);

            await organizationService.AssignNewRoleAsync(orgMicrosoft.Id, employeeVadim.Id, developerRole.Id, null);

            employeeIvan.Name = "UpdateIvan";
            await employeeService.UpdateAsync(employeeIvan);

            await employeeService.RemoveAsync(employeeAlex);
            await roleService.RemoveAsync(qaRole);
            await organizationService.RemoveEmployeeAsync(orgEpam.Id, employeeIvan.Id);

            Console.WriteLine("All Employees:");

            var allEmployees = await employeeService.GetAsync();

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"Employee: {employee.Id} {employee.Name}");

                foreach (var employeeRole in employee.EmployeeRoles)
                {
                    Console.WriteLine($"Company: {employeeRole.Organization.Name}, Role: {employeeRole.Role.Name}");
                }

                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
