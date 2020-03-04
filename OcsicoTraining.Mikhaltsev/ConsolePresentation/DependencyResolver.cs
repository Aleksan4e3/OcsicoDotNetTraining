using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopDAL.Context;
using ShopDAL.Repositories;
using ShopDAL.Repositories.Contracts;

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
            serviceCollection.AddTransient<IImageRepository, ImageRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
