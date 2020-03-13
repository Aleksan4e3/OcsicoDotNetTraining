using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProductService : IProductService
    {
        private readonly IDataContext dataContext;
        private readonly IProductRepository productRepository;
        private readonly IFileConverter fileConverter;
        private readonly IMapper mapper;

        public ProductService(IDataContext dataContext,
            IProductRepository productRepository,
            IFileConverter fileConverter,
            IMapper mapper)
        {
            this.dataContext = dataContext;
            this.productRepository = productRepository;
            this.fileConverter = fileConverter;
            this.mapper = mapper;
        }

        public async Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model)
        {
            var product = mapper.Map<Product>(model);

            product.ImageUrl = await fileConverter.SaveFileAsync(model.Image);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return model;
        }

        public async Task<ProductViewModel> CreateAsync(ProductViewModel model)
        {
            var product = mapper.Map<Product>(model);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<ProductForOrderViewModel>> GetAsync()
        {
            var products = await productRepository.GetQuery().ToListAsync();

            return mapper.Map<List<ProductForOrderViewModel>>(products);
        }

        public async Task<List<ProductForOrderViewModel>> GetForMenuAsync()
        {
            var collectionId = await productRepository
                .GetQuery()
                .Select(x => x.ParentProductId)
                .ToListAsync();

            var products = await productRepository
                .GetQuery()
                .Where(x => !collectionId.Contains(x.Id))
                .ToListAsync();

            return products.Select(Map).ToList();
        }

        public async Task<ProductViewModel> GetAsync(Guid id)
        {
            var product = await productRepository
                .GetQuery()
                .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ProductViewModel>(product);
        }

        private ProductForOrderViewModel Map(Product model)
        {
            return new ProductForOrderViewModel
            {
                ProductId = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = fileConverter.ToBase64(model.ImageUrl)
            };
        }
    }
}
