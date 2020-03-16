using System;
using System.Threading.Tasks;
using AutoMapper;
using EntityModels.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.contextAccessor = contextAccessor;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(RegisterViewModel model)
        {
            var user = mapper.Map<User>(model);

            return await userManager.CreateAsync(user, model.Password);
        }

        public Guid GetUserId()
        {
            var user = contextAccessor.HttpContext.User;
            var userId = Guid.Parse(userManager.GetUserId(user));

            return userId;
        }

        public async Task<string> GetEmail()
        {
            var userClaims = contextAccessor.HttpContext.User;
            var user = await userManager.GetUserAsync(userClaims);

            return await userManager.GetEmailAsync(user);
        }

        public async Task LogInAsync(RegisterViewModel model)
        {
            await signInManager.PasswordSignInAsync(model.UserName,
                model.Password, false, false);
        }

        public async Task<SignInResult> PasswordLogInAsync(LoginViewModel model)
        {
            return await signInManager.PasswordSignInAsync(model.UserName,
                model.Password, model.IsRemember, false);
        }

        public async Task LogOutAsync() => await signInManager.SignOutAsync();
    }
}
