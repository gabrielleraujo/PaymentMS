using Microsoft.EntityFrameworkCore;
using PaymentMS.Data.Configurations;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Data.Context
{
    public class PaymentMSContext : DbContext
    {
        public PaymentMSContext(DbContextOptions options) : base(options) { }

        public DbSet<CreditCard> CreditCardPayments { get; set; }
        public DbSet<DebitCard> DebitCardPayments { get; set; }
        public DbSet<Boleto> BoletoPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new DebitCardConfiguration());
            modelBuilder.ApplyConfiguration(new BoletoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}