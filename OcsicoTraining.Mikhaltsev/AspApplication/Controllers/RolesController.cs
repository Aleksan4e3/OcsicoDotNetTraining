using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await roleService.GetAllAsync();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);
            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await roleService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                await roleService.UpdateAsync(role);

                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await roleService.GetViewModelAsync(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, RoleViewModel role)
        {
            await roleService.RemoveAsync(role);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> RoleSearch(string name)
        {
            var roles = await roleService.SearchAsync(name);

            return PartialView("_RolesSearch", roles);
        }
    }
}
