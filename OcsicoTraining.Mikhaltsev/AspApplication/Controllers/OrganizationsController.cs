using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await organizationService.GetAllAsync();
            return View(organizations);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employeeRoles = await organizationService.GetEmployeeRolesViewModelAsync(id);
            return View(employeeRoles);
        }

        [HttpGet]
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

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminOrOrganization)]
        public async Task<IActionResult> Add(Guid id)
        {
            var model = await CreateModelForAddAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesAdd(Guid organizationId, Guid employeeId)
        {
            var rolesCurrentEmployee = await organizationService.GetRolesSelectListAsync(organizationId, employeeId);
            var allRoles = await roleService.GetRolesSelectListAsync();
            var rolesAdd = allRoles.Where(x => !rolesCurrentEmployee.Select(y => y.Id).Contains(x.Id));

            return Json(rolesAdd);
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

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminOrOrganization)]
        public async Task<IActionResult> Remove()
        {
            var model = await CreateModelForRemoveAsync();

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

            model = await CreateModelForRemoveAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(Guid id)
        {
            var employees = await organizationService.GetEmployeesSelectListAsync(id);
            return Json(employees);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminOrOrganization)]
        public async Task<IActionResult> AssignRole(Guid id)
        {
            var model = await CreateModelForAssignRoleAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles(Guid organizationId, Guid employeeId)
        {
            var rolesCurrentEmployee = await organizationService.GetRolesSelectListAsync(organizationId, employeeId);
            var allRoles = await roleService.GetRolesSelectListAsync();
            var rolesAdd = allRoles.Where(x => !rolesCurrentEmployee.Select(y => y.Id).Contains(x.Id));

            return Json(new[] { rolesAdd, rolesCurrentEmployee });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(AssignNewRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await organizationService.AssignNewRoleAsync(model);

                return RedirectToAction(nameof(Index));
            }

            model = await CreateModelForAssignRoleAsync(model.OrganizationId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OrganizationsSearch(string name)
        {
            var organizations = await organizationService.SearchAsync(name);

            return PartialView("_OrganizationsSearch", organizations);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.AdminOrOrganization)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var organization = await organizationService.GetAsync(id);
            await organizationService.RemoveAsync(organization);
            var organizations = await organizationService.GetAllAsync();

            return PartialView("_OrganizationsSearch", organizations);
        }

        [NonAction]
        private async Task<AddEmployeeToOrganizationViewModel> CreateModelForAddAsync(Guid id)
        {
            var employees = await employeeService.GetEmployeesSelectList();

            return new AddEmployeeToOrganizationViewModel
            {
                OrganizationId = id,
                Employees = employees.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }

        [NonAction]
        private async Task<RemoveEmployeeViewModel> CreateModelForRemoveAsync()
        {
            var organizations = await organizationService.GetAsync();

            return new RemoveEmployeeViewModel
            {
                Organizations = organizations.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }

        [NonAction]
        private async Task<AssignNewRoleViewModel> CreateModelForAssignRoleAsync(Guid id)
        {
            var employees = await organizationService.GetEmployeesSelectListAsync(id);

            return new AssignNewRoleViewModel
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
