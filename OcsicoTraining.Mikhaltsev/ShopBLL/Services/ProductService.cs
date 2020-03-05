using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using EntityModels;
using Microsoft.AspNetCore.Http;
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
            var product = Map(model);

            await productRepository.AddAsync(product);
            await dataContext.SaveChangesAsync();

            return model;
        }

        private string GetStringFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return Convert.ToBase64String(target.ToArray());
            }
        }

        private Product Map(CreateProductViewModel model)
        {
            var image = new Image
            {
                Name = model.ImageName,
                Data = GetStringFromImage(model.Image)
            };

            return new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ParentProductId = model.SelectedParentId,
                Image = image
            };
        }
    }
}
