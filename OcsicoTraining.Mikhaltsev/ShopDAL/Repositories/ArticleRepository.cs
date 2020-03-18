using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;

namespace ShopDAL.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
