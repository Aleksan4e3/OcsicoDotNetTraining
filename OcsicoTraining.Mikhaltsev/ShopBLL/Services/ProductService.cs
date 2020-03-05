using System.Threading.Tasks;
using AutoMapper;
using EntityModels;
using ShopBLL.Services.Contracts;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataContext dataContext;
        private readonly IProductRepository productRepository;
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;

        public ProductService(IDataContext dataContext,
            IProductRepository productRepository,
            IImageRepository imageRepository,
            IMapper mapper)
        {
            this.dataContext = dataContext;
            this.productRepository = productRepository;
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model)
        {
            var product = mapper.Map<Product>(model);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return mapper.Map<CreateProductViewModel>(product);
        }
    }
}
