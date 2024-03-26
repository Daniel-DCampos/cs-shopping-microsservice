using CSShopping.ProductAPI.Repository;

namespace CSShopping.ProductAPI.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
