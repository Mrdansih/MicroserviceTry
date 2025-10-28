﻿using Application.Product.ServiceInterfaces;
using Application.Product.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Product
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
