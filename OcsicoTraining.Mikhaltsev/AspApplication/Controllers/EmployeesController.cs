using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await service.GetAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await service.GetAsync(id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
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
            var employee = await service.GetAsync(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await service.GetAsync(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Employee employee)
        {
            await service.RemoveAsync(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
