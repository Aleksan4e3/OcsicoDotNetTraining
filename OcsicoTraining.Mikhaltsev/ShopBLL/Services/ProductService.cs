using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using Microsoft.AspNetCore.Http;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataContext dataContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IDataContext dataContext,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.dataContext = dataContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model)
        {
            var product = mapper.Map<Product>(model);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return model;
        }

        //public async Task<List<ProductViewModel>> GetAsync()
        //{
        //    var products = await productRepository.GetQuery().ToListAsync();


        //}

        private string GetStringFromImage(IFormFile file)
        {
            using var target = new MemoryStream();
            file.CopyTo(target);

            return Convert.ToBase64String(target.ToArray());
        }
    }
}
