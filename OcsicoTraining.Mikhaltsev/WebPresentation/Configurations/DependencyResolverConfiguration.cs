using Microsoft.Extensions.DependencyInjection;
using ShopBLL.Services;
using ShopBLL.Services.Contracts;
using ShopDAL.Repositories;
using ShopDAL.Repositories.Contracts;

namespace WebPresentation.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
