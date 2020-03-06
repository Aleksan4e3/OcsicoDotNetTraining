using System.Threading.Tasks;
using AutoMapper;
using EntityModels.Identity;
using Microsoft.AspNetCore.Identity;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(RegisterViewModel model)
        {
            var user = mapper.Map<User>(model);

            return await userManager.CreateAsync(user, model.Password);
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
