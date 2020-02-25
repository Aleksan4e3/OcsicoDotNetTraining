using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService organizationService;
        private readonly IEmployeeService employeeService;

        public OrganizationsController(IOrganizationService organizationService, IEmployeeService employeeService)
        {
            this.organizationService = organizationService;
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var organizations = await organizationService.GetAsync();
            return View(organizations);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var employeeRoles = await organizationService.GetEmployeeRolesAsync(id);
            return View(employeeRoles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrganizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await organizationService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var employees = await employeeService.GetEmployeesSelectList();


            var model = new AddEmployeeToOrganizationViewModel
            {
                Employees = employees.Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.Id.ToString()
                }).ToList()
            };

            return View(model);
        }
    }
}
