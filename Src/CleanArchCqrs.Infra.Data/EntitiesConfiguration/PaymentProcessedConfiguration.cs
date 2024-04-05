using CleanArchCqrs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchCqrs.Infra.Data.EntitiesConfiguration
{
    public class PaymentProcessedConfiguration : IEntityTypeConfiguration<PaymentProcessed>
    {
        public void Configure(EntityTypeBuilder<PaymentProcessed> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasOne(e => e.Payment).WithMany(e => e.PaymentProcesseds).HasForeignKey(e => e.PaymentId);
        }
    }
}
