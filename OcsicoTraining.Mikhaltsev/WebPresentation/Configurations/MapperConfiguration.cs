using MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace WebPresentation.Configurations
{
    public static class MapperConfiguration
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(ProductProfile));
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
