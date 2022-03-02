using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentMS.Data.Context;

namespace PaymentMS.Infrastructure.IoC
{
    public static class Database
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<PaymentMSContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("PaymentConnection")));
        }
    }
}