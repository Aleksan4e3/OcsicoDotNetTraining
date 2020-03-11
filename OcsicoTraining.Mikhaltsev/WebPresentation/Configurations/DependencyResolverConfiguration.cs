using ContractsDAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ShopBLL.Services;
using ShopBLL.Services.Contracts;
using ShopDAL.Repositories;
using WebPresentation.Infrastructure.Context;

namespace WebPresentation.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IContextService, HttpContextService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IArticleService, ArticleService>();

            services.AddHttpContextAccessor();
        }
    }
}
