using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IProductService
    {
        Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model);
    }
}
