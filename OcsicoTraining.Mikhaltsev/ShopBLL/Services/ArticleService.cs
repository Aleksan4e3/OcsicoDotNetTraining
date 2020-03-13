using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly IDataContext dataContext;
        private readonly IFileConverter fileConverter;
        private readonly IMapper mapper;

        public ArticleService(IArticleRepository articleRepository,
            IDataContext dataContext,
            IFileConverter fileConverter,
            IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.dataContext = dataContext;
            this.fileConverter = fileConverter;
            this.mapper = mapper;
        }

        public async Task<List<ArticleViewModel>> GetAsync()
        {
            var articles = await articleRepository.GetQuery().ToListAsync();

            return mapper.Map<List<ArticleViewModel>>(articles);
        }

        public async Task<CreateArticleViewModel> CreateAsync(CreateArticleViewModel model)
        {
            var article = mapper.Map<Article>(model);

            article.ImageUrl = await fileConverter.SaveFileAsync(model.ImageUrl);

            await articleRepository.AddAsync(article);
            await dataContext.SaveChangesAsync();

            return model;
        }
    }
}
