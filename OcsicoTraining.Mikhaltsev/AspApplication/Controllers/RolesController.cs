using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService service;

        public RolesController(IRoleService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await service.GetAsync();
            return View(roles);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var role = await service.GetAsync(id);
            return View(role);
        }

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
                await service.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var role = await service.GetAsync(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Role role)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(role);

                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await service.GetAsync(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Role role)
        {
            await service.RemoveAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}
