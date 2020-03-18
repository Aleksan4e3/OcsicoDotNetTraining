using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, OrderViewModel model);
        Task SendEmailChangeStatusAsync(string email, OrderViewModel model);
    }
}
