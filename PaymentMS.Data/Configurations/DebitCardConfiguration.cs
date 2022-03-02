using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentMS.Data.Utils;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Data.Configurations
{
    public class DebitCardConfiguration : IEntityTypeConfiguration<DebitCard>
    {
        public void Configure(EntityTypeBuilder<DebitCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PurchaseId);
            builder.Property(x => x.AmountToBePaid);
            builder.Property(x => x.Number);
            builder.Property(x => x.Agency);

            builder.Property(x => x.State)
                .HasColumnName("Status")
                .HasConversion(
                    v => v.GetType().Name,
                    v => v.GetState());
        }
    }
}