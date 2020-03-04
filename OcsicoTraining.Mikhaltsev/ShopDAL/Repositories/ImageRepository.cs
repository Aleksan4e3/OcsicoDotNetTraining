using EntityModels;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ShopDAL.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
