using Application.Order.ServiceInterfaces;
using Application.Order.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Order
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderEventPublisher, OrderEventPublisher>();

            return services;
        }
    }
}
