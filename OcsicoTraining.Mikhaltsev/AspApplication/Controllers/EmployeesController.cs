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
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await employeeService.GetAsync(id);
            return View(employee);
        }

        [HttpGet]
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
                await employeeService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await employeeService.GetAsync(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.UpdateAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetAsync(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Employee employee)
        {
            await employeeService.RemoveAsync(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
