using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentMS.Data.Utils;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Data.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PurchaseId);
            builder.Property(x => x.AmountToBePaid);
            builder.Property(x => x.Number);
            builder.Property(x => x.Agency);
            builder.Property(x => x.NumberInstallments);
            builder.Property(x => x.NumberInstallmentsPaid);
            builder.Property(x => x.InstallmentValue);

            builder.Property(x => x.State)
                .HasColumnName("Status")
                .HasConversion(
                    v => v.GetType().Name,
                    v => v.GetState());
        }
    }
}