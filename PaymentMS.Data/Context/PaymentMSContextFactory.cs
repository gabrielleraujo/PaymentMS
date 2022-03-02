using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PaymentMS.Data.Context;

namespace ProductContext.Infrastructure.Data.SqlServer.Context
{
    public class PaymentMSContextFactory : IDesignTimeDbContextFactory<PaymentMSContext>
    {
        //método utilizado pelo Migrations para inicializar a classe
        //PaymentContext utilizando os atributos do appsettings.json
        public PaymentMSContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PaymentMSContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new PaymentMSContext(builder.Options);
        }
    }
}