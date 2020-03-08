using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using EntityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopBLL.Services.Contracts;
using ViewModels;

namespace ShopBLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataContext dataContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductService(IDataContext dataContext,
            IProductRepository productRepository,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            this.dataContext = dataContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<CreateProductViewModel> CreateAsync(CreateProductViewModel model)
        {
            var product = mapper.Map<Product>(model);

            product.ImageUrl = await SaveImageAsync(model.Image);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<ProductForOrderViewModel>> GetAsync()
        {
            var products = await productRepository.GetQuery().ToListAsync();

            return mapper.Map<List<ProductForOrderViewModel>>(products);
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
