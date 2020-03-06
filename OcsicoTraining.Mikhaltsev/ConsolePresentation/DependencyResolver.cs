using System;
using AutoMapper;
using ContractsDAL.Context;
using ContractsDAL.Repositories;
using MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopBLL.Services;
using ShopBLL.Services.Contracts;
using ShopDAL.Context;
using ShopDAL.Repositories;

namespace ConsolePresentation
{
    public class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IDataContext, DataContext>();
            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-BHOPAQ4\\SQLEXPRESS;Initial Catalog=PiesShop;Integrated Security=True;")
                    .UseLazyLoadingProxies());
            serviceCollection.AddTransient<IArticleRepository, ArticleRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IProductService, ProductService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(ProductProfile));
            });

            var mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
