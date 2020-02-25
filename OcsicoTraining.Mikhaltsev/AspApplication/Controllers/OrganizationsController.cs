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
        private readonly IRoleService roleService;

        public OrganizationsController(IOrganizationService organizationService,
            IEmployeeService employeeService,
            IRoleService roleService)
        {
            this.organizationService = organizationService;
            this.employeeService = employeeService;
            this.roleService = roleService;
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

        public async Task<IActionResult> Add(Guid id)
        {
            var model = await CreateModelForAddAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddEmployeeToOrganizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await organizationService.AttachEmployeeAsync(model);

                return RedirectToAction(nameof(Index));
            }

            model = await CreateModelForAddAsync(model.OrganizationId);

            return View(model);
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var model = await CreateModelForRemoveAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(RemoveEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await organizationService.RemoveEmployeeAsync(model);

                return RedirectToAction(nameof(Index));
            }

            model = await CreateModelForRemoveAsync(model.OrganizationId);

            return View(model);
        }

        [NonAction]
        private async Task<AddEmployeeToOrganizationViewModel> CreateModelForAddAsync(Guid id)
        {
            var employees = await employeeService.GetEmployeesSelectList();
            var roles = await roleService.GetRolesSelectList();

            return new AddEmployeeToOrganizationViewModel
            {
                OrganizationId = id,

                Employees = employees.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList(),

                Roles = roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }

        [NonAction]
        private async Task<RemoveEmployeeViewModel> CreateModelForRemoveAsync(Guid id)
        {
            var employees = await organizationService.GetEmployeesSelectList(id);

            return new RemoveEmployeeViewModel
            {
                OrganizationId = id,

                Employees = employees.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }
    }
}
