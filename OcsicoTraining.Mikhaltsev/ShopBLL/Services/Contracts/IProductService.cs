using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IProductService
    {
        Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model);
        Task<List<ProductForOrderViewModel>> GetAsync();
    }
}
