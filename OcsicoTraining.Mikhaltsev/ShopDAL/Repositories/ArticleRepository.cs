using EntityModels;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ShopDAL.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
