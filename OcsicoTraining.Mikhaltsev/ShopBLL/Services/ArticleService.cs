using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly IDataContext dataContext;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public ArticleService(IArticleRepository articleRepository,
            IDataContext dataContext,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.dataContext = dataContext;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }

        public async Task<CreateArticleViewModel> CreateAsync(CreateArticleViewModel model)
        {
            var article = mapper.Map<Article>(model);

            article.ImageUrl = await SaveImageAsync(model.ImageUrl);

            await articleRepository.AddAsync(article);
            await dataContext.SaveChangesAsync();

            return model;
        }

        private async Task<string> SaveImageAsync(IFormFile uploadedFile)
        {
            var path = string.Empty;

            if (uploadedFile != null)
            {
                path = "/Images/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(hostingEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }

            return path;
        }
    }
}
