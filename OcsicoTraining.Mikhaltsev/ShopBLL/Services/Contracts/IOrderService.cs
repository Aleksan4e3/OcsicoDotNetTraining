using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateAsync(OrderViewModel model);
    }
}
