using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PaymentMS.Infrastructure.IoC
{
    public static class Swagger
    {
        public static void AddSwaggerGenConfig(this IServiceCollection service)
        {
            service.AddApiVersioning();

            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Payment API",
                    Description = "API Documentation",
                    Version = "1.0",
                    Contact = new OpenApiContact { Name = "Gabrielle", Url = new Uri("https://gabrielleraujo.github.io/") }
                });

                options.EnableAnnotations();
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment v1.0");
            }); 
        }
    }
}