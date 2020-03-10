using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IOrderDetailService
    {
        Task AddAsync(OrderDetailViewModel model);
        OrderDetailViewModel CalculateTotal(OrderDetailViewModel model);
    }
}
