using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService service;

        public OrganizationsController(IOrganizationService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var organizations = await service.GetAsync();
            return View(organizations);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var employees = service.GetEmployeesAsync(id);
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
