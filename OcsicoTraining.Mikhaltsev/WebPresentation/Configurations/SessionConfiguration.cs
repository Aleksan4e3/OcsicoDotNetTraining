using Microsoft.Extensions.DependencyInjection;

namespace WebPresentation.Configurations
{
    public static class SessionConfiguration
    {
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "App.Session";
                options.Cookie.IsEssential = true;
            });
        }
    }
}
