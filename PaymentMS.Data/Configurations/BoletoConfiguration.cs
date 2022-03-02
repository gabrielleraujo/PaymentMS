using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentMS.Data.Utils;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Data.Configurations
{
    public class BoletoConfiguration : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PurchaseId);
            builder.Property(x => x.AmountToBePaid);
            builder.Property(x => x.BarCode);
            builder.Property(x => x.DueDate);

            builder.Property(x => x.State)
                .HasColumnName("Status")
                .HasConversion(
                    v => v.GetType().Name,
                    v => v.GetState());
        }
    }
}