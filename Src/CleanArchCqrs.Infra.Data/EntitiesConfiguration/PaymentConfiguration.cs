using CleanArchCqrs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchCqrs.Infra.Data.EntitiesConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasOne(e => e.Agent).WithMany(e => e.Payments).HasForeignKey(e => e.AgentId);
            builder.HasOne(e => e.Product).WithMany(e => e.Payments).HasForeignKey(e => e.ProductId);
        }
    }
}
