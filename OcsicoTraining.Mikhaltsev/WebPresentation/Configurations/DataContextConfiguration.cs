using ContractsDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDAL.Context;

namespace WebPresentation.Configurations
{
    public static class DataContextConfiguration
    {
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataContext, DataContext>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                    .UseLazyLoadingProxies());
        }
    }
}
