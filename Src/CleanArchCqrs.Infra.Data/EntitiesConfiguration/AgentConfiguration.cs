﻿using CleanArchCqrs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchCqrs.Infra.Data.EntitiesConfiguration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Agent(1, "Fernando José", "fernandogjose@gmail.com"),
                new Agent(2, "Priscila Antunes", "priscilaantunes@gmail.com"),
                new Agent(3, "Gabriel Antunes", "gabrielantunes@gmail.com"),
                new Agent(4, "Beatriz Antunes", "beatrizantunes@gmail.com"));
        }
    }
}
