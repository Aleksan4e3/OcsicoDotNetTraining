using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IArticleService
    {
        Task<CreateArticleViewModel> CreateAsync(CreateArticleViewModel model);
    }
}
