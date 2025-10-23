using Application.Auth.ServiceInterfaces;
using Application.Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
