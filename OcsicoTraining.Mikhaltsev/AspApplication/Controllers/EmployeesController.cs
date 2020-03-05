using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var employees = await employeeService.GetAllAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await employeeService.GetViewModelAsync(id);
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
            var employee = await employeeService.GetViewModelAsync(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmployeeViewModel employee)
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
            var employee = await employeeService.GetViewModelAsync(id);

            await employeeService.RemoveAsync(employee);

            var employees = await employeeService.GetAllAsync();

            return PartialView("_EmployeesSearch", employees);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeSearch(string name)
        {
            var employees = await employeeService.SearchAsync(name);

            return PartialView("_EmployeesSearch", employees);
        }
    }
}
