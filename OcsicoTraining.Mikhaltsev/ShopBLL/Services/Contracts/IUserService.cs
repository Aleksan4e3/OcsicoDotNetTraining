using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(RegisterViewModel model);
        Guid GetUserId();
        Task LogInAsync(RegisterViewModel model);
        Task<SignInResult> PasswordLogInAsync(LoginViewModel model);
        Task LogOutAsync();
    }
}
