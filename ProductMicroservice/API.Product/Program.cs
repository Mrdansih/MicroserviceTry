using Application.Product;
using Application.Product.Services;
using Persistence.Product;

namespace API.Product
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHostedService<StockUpdateConsumer>();

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
