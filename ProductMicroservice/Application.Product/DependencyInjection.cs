using Application.Product.ServiceInterfaces;
using Application.Product.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Product
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockEventProducer, StockEventProducer>();
            services.AddHostedService<StockUpdateConsumer>();
            return services;
        }
    }
}
