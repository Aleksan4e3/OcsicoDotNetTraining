using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace ShopBLL.Services.Contracts
{
    public interface IArticleService
    {
        Task<CreateArticleViewModel> CreateAsync(CreateArticleViewModel model);
        Task<List<ArticleViewModel>> GetAsync();
        Task<ArticleViewModel> GetAsync(Guid id);
    }
}
