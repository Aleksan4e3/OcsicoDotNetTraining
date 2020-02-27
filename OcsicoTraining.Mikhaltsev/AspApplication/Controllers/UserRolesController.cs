using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var identityRoles = roleManager.Roles
                .Select(x => new IdentityRoleViewModel { Id = x.Id, Name = x.Name })
                .ToList();

            return View(identityRoles);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                await roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var users = userManager.Users.Select(x => new UserViewModel { Id = x.Id, Email = x.Email }).ToList();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            // get user
            var user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                // get a list of user roles
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();
                var model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // get user
            var user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
