using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IOrganizationService service;

        public OrganizationsController(AppDbContext context, IOrganizationService service)
        {
            _context = context;
            this.service = service;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            var employeeRoles = await service.GetAsync();
            //var appDbContext = _context.EmployeeRoles.Include(e => e.Employee).Include(e => e.Organization).Include(e => e.Role);
            return View(employeeRoles);
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.Employee)
                .Include(e => e.Organization)
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,OrganizationId,RoleId")] EmployeeRole employeeRole)
        {
            if (ModelState.IsValid)
            {
                employeeRole.EmployeeId = Guid.NewGuid();
                _context.Add(employeeRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeRole.EmployeeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Name", employeeRole.OrganizationId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", employeeRole.RoleId);
            return View(employeeRole);
        }

        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRole == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeRole.EmployeeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Name", employeeRole.OrganizationId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", employeeRole.RoleId);
            return View(employeeRole);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmployeeId,OrganizationId,RoleId")] EmployeeRole employeeRole)
        {
            if (id != employeeRole.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRoleExists(employeeRole.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeRole.EmployeeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Name", employeeRole.OrganizationId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", employeeRole.RoleId);
            return View(employeeRole);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.Employee)
                .Include(e => e.Organization)
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(employeeRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRoleExists(Guid id)
        {
            return _context.EmployeeRoles.Any(e => e.EmployeeId == id);
        }
    }
}
